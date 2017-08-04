using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Data;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.UserControl;

namespace SpecialLogisticsSystem.AppPortal.Business
{
    public partial class SendProduction : BasePage<SendProduction>
    {
        [Dependency]
        public IArrivalDeliverDal _deliver { get; set; }
        [Dependency]
        public IArrivalDeliverGoodsDal _deliver_detail { get; set; }
        [Dependency]
        public ICmCustomerDal _customer { get; set; }

        private static string strSeeionID = "id";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.Deliver;
                }
                if (null != Session[Constants.DeliverDetail])
                {
                    Session[Constants.DeliverDetail] = null;
                }
            }
        }


        #region 送货单

        protected void gridDeliver_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            Session[Constants.DeliverDetail] = null;
        }

        protected void DeliverDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridDeliver.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridDeliver.FilterExpression) ? gridDeliver.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }


        protected void gridDeliver_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            //1. 保存发车信息 2. 保存运单
            T_Arrival_Deliver deliver = new T_Arrival_Deliver();
            UIHelpers.TryUpdateModel<T_Arrival_Deliver>.ToUpdateModel(deliver, gridDeliver);
            deliver.id = Guid.NewGuid();
            deliver.deliver_statue = WayStatue.Outbound.ToString();
            _deliver.Insert(deliver);
            //运单
            var detailList = Session[Constants.DeliverDetail] as List<T_Arrival_DeliverGoods>;
            if (detailList != null)
            {
                detailList.ForEach((p) =>
                {
                    p.deliver_id = deliver.id;
                    _deliver_detail.Insert(p);
                });
                Session[Constants.DeliverDetail] = null;
            }
            FinishGrid(e);
            gridDeliver.JSProperties[Constants.strCpShowPopup] = deliver.id.ToString();
        }

        protected void gridDeliver_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Arrival_Deliver deliver = _deliver.GetSingle(e.Keys[0]);
            UIHelpers.TryUpdateModel<T_Arrival_Deliver>.ToUpdateModel(deliver, gridDeliver);
            _deliver.Update(deliver);
            ////货物 先删除 后添加（因为不清楚是新增或修改）
            //_stowaye_detail.DeleteByWay(deliver.id);
            QueryInfo<T_Arrival_DeliverGoods> queryInfo = new QueryInfo<T_Arrival_DeliverGoods>();
            queryInfo.SetQuery(T_Arrival_DeliverGoods.MainIdColumnName, deliver.id);
            List<T_Arrival_DeliverGoods> oldDetailList = _deliver_detail.GetList(queryInfo).ToList();
            List<T_Arrival_DeliverGoods> detailList = Session[Constants.DeliverDetail] as List<T_Arrival_DeliverGoods>;
            SequenceCalculator<T_Arrival_DeliverGoods> cal = new SequenceCalculator<T_Arrival_DeliverGoods>(oldDetailList, detailList);
            if (cal.ToBeDeletedSequence.Count > 0)
            {
                _deliver_detail.Delete(cal.ToBeDeletedSequence.Select(p => p.id).ToList());
            }
            foreach (var item in cal.ToBeUpdatedSequence)
            {
                _deliver_detail.Update(item);
            }
            foreach (var item in cal.ToBeInsertedSequence)
            {
                item.deliver_id = deliver.id;
                _deliver_detail.Insert(item);
            }
            Session[Constants.DeliverDetail] = null;
            //if (detailList != null)
            //{
            //    foreach (var item in detailList)
            //    {
            //        item.bill_id = deliver.id;
            //        _stowaye_detail.Insert(item);
            //    }
            //}
            FinishGrid(e);
        }

        protected void gridDeliver_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> ids = gridDeliver.GetSelectedFieldValues(gridDeliver.KeyFieldName);
            _deliver.Delete(ids);
            FinishGrid(e);
            gridDeliver.DataBind();
            gridDeliver.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }


        private void ErrorGrid(string way_name, string other_name, CancelEventArgs e)
        {
            string message = string.Format(Constants.strCannotDelete, way_name, other_name);
            gridDeliver.JSProperties[Constants.strCpMessage] = message;
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridDeliver.CancelEdit();
            gridDeliver.DataBind();
        }


        protected void gridDeliver_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
            if (!grid.IsNewRowEditing)
            {
                object id = grid.GetRowValues(grid.EditingRowVisibleIndex, grid.KeyFieldName);
                UpdateControll<T_Arrival_Deliver>.SetValueToControl(grid);
                List<T_Arrival_DeliverGoods> cList = Session[Constants.DeliverDetail] as List<T_Arrival_DeliverGoods>;
                if (Session[strSeeionID] != null && id.ToString() != Session[strSeeionID].ToString())
                {
                    Session[Constants.DeliverDetail] = null;
                    cList = null;
                }
                Session[strSeeionID] = id;
                if (cList == null)
                {
                    QueryInfo<T_Arrival_DeliverGoods> queryInfo = new QueryInfo<T_Arrival_DeliverGoods>();
                    queryInfo.SetQuery(T_Arrival_DeliverGoods.MainIdColumnName, id);
                    List<T_Arrival_DeliverGoods> productionList = _deliver_detail.GetList(queryInfo).ToList();
                    Session[Constants.DeliverDetail] = productionList;
                }
                var gridDeliverDetail = grid.FindEditFormTemplateControl("gridDeliverDetail") as SpecialLogisticsSystem.UserControl.ASPxGridView;
                //gridDeliverDetail.DataSource = Session[Constants.DeliverDetail] as List<T_Arrival_DeliverGoods>;
                gridDeliverDetail.DataBind();
            }
        }


        #endregion

        #region 运单信息

        protected void gridDeliverDetail_Load(object sender, EventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            var id = grid.GetMasterRowKeyValue();
            QueryInfo<T_Arrival_DeliverGoods> queryInfo = new QueryInfo<T_Arrival_DeliverGoods>();
            queryInfo.SetQuery("main_id", id);
            grid.DataSource = _deliver_detail.Select(queryInfo);
            grid.DataBind();
        }

        protected void gridDeliverDetail_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            if (e.VisibleIndex == -1)
                return;
            int index = e.VisibleIndex;
            List<T_Arrival_DeliverGoods> lists = Session[Constants.DeliverDetail] as List<T_Arrival_DeliverGoods>;
            ASPxTextBox txtSendBill = grid.FindRowCellTemplateControl(index, grid.Columns["send_bill"] as GridViewDataColumn, "txtSendBill") as ASPxTextBox;
            txtSendBill.Text = lists[index].send_bill.ToString();
        }


        protected void gridDeliverDetail_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            if (e.Parameters == "Update")
            {
                for (int index = 0; index < grid.VisibleRowCount; index++)
                {
                    ASPxTextBox txtSendBill = grid.FindRowCellTemplateControl(index, grid.Columns["send_bill"] as GridViewDataColumn, "txtSendBill") as ASPxTextBox;
                    Guid id = ConvertHelper.ObjectToGuid(grid.GetRowValues(index, "id")).Value;
                    List<T_Arrival_DeliverGoods> lists = Session[Constants.DeliverDetail] as List<T_Arrival_DeliverGoods>;
                    lists.ForEach(a =>
                    {
                        if (a.id == id)
                        {
                            a.send_bill = ConvertHelper.ObjectToDecimal(txtSendBill.Value);
                        }
                    });
                    Session[Constants.DeliverDetail] = lists;
                }
            }
        }

        ///// <summary>
        ///// grid 没有caching 只能用这种绑定
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void gridDeliverDetail_DataBinding(object sender, EventArgs e)
        //{
        //    var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
        //    grid.DataSource = Session[Constants.DeliverDetail] as List<T_Arrival_DeliverGoods>;
        //}

        private void BindDetail(SpecialLogisticsSystem.UserControl.ASPxGridView grid, CancelEventArgs e, List<T_Arrival_DeliverGoods> detailList)
        {
            Session[Constants.DeliverDetail] = detailList;
            e.Cancel = true;
            grid.CancelEdit();
            if (null == Session[Constants.DeliverDetail]) return;
            grid.DataSource = Session[Constants.DeliverDetail] as List<T_Arrival_DeliverGoods>;
            grid.DataBind();
        }
     
        #endregion
    }
}