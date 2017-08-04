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
    public partial class Transfer : BasePage<Transfer>
    {
        [Dependency]
        public ITransferMainDal _transfer { get; set; }
        [Dependency]
        public ITransferDetailDal _transfer_detail { get; set; }
        [Dependency]
        public ICmCustomerDal _customer { get; set; }
        [Dependency]
        public IFinanceServiceDal _finance_service { get; set; }
        [Dependency]
        public ICmServicerDal _service { get; set; }
        [Dependency]
        public ICmLinkDal _link { get; set; }
        [Dependency]
        public ICmSequenceNumberDal _number { get; set; }
        

        private static string strCalTotal = "CalTotal";
        private static string strSeeionID = "id";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.Transfer;
                }
                if (null != Session[Constants.TransferDetail])
                {
                    Session[Constants.TransferDetail] = null;
                }
            }
        }

        #region 发车单

        protected void transferDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridTransfer.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridTransfer.FilterExpression) ? gridTransfer.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }

        protected void gridTransfer_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            Session[Constants.TransferDetail] = null;
        }

        protected void gridTransfer_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            //1. 保存中转信息 2. 保存运单
            T_Transfer_Main transfer = new T_Transfer_Main();
            UIHelpers.TryUpdateModel<T_Transfer_Main>.ToUpdateModel(transfer, gridTransfer);
            transfer.service_id = SaveServicer(transfer);
            transfer.id = Guid.NewGuid();
            transfer.transfer_statue = WayStatue.Transfer.ToString();
            _transfer.Insert(transfer);
            //运单
            var detailList = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
            if (detailList != null)
            {
                detailList.ForEach((p) =>
                {
                    p.main_id = transfer.id;
                    _transfer_detail.Insert(p);
                });
                Session[Constants.TransferDetail] = null;
            }
            FinishGrid(e);
            //gridTransfer.JSProperties[Constants.strCpShowPopup] = transfer.id.ToString();
        }

        protected void gridTransfer_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Transfer_Main transfer = _transfer.GetSingle(e.Keys[0]);
            UIHelpers.TryUpdateModel<T_Transfer_Main>.ToUpdateModel(transfer, gridTransfer);
            SaveServicer(transfer);
            _transfer.Update(transfer);
            ////货物 先删除 后添加（因为不清楚是新增或修改）
            //_stowaye_detail.DeleteByWay(stowage.id);
            QueryInfo<T_Transfer_Detail> queryInfo = new QueryInfo<T_Transfer_Detail>();
            queryInfo.SetQuery(T_Transfer_Detail.MainIdColumnName, transfer.id);
            List<T_Transfer_Detail> oldDetailList = _transfer_detail.GetList(queryInfo).ToList();
            List<T_Transfer_Detail> detailList = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
            SequenceCalculator<T_Transfer_Detail> cal = new SequenceCalculator<T_Transfer_Detail>(oldDetailList, detailList);
            if (cal.ToBeDeletedSequence.Count > 0)
            {
                _transfer_detail.Delete(cal.ToBeDeletedSequence.Select(p => p.id).ToList());
            }
            foreach (var item in cal.ToBeUpdatedSequence)
            {
                _transfer_detail.Update(item);
            }
            foreach (var item in cal.ToBeInsertedSequence)
            {
                item.main_id = transfer.id;
                _transfer_detail.Insert(item);
            }
            Session[Constants.TransferDetail] = null;
            //if (detailList != null)
            //{
            //    foreach (var item in detailList)
            //    {
            //        item.bill_id = stowage.id;
            //        _stowaye_detail.Insert(item);
            //    }
            //}
            FinishGrid(e);
        }

        protected Guid SaveServicer(T_Transfer_Main main)
        {
            bool isAdd = (main.service_id == null || main.service_id == Guid.Empty);
            Guid id = isAdd ? Guid.NewGuid() : main.service_id;
            if (isAdd)
            {
                T_Cm_Link link = new T_Cm_Link();
                link.id = Guid.NewGuid();
                link.link_name = main.link_name;
                link.link_mobilephone = main.link_mobilephone;
                link.link_address = main.get_address;

                T_Cm_Servicer servicer = new T_Cm_Servicer();
                servicer.code = _number.GetNumber(CodeTable.Servicer);
                servicer.id = id;
                servicer.name = main.service_name;
                _link.Insert(link);
                servicer.link_id = link.id;
                _service.Insert(servicer);
            }
            else
            {
                T_Cm_Servicer servicer = _service.GetSingle(id);
                T_Cm_Link link = _link.GetSingle(servicer.link_id);
                link.link_name = main.link_name;
                link.link_mobilephone = main.link_mobilephone;
                link.link_address = main.get_address;
                _link.Update(link);
                servicer.name = main.service_name;
                _service.Update(servicer);
            }
            return id;
        }

        protected void gridTransfer_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> idAndCode = gridTransfer.GetSelectedFieldValues(new string[] { gridTransfer.KeyFieldName, T_Transfer_Main.TransferNumberColumnName });
            foreach (object[] id_name in idAndCode)
            {
                var id = id_name[0];
                var name = id_name[1].ToString();
                //与服务商结算关联
                IList<T_Finance_Service> serviceList = _finance_service.GetList(new QueryInfo<T_Finance_Service>().SetQuery(T_Finance_Service.TransferIDColumnName, id));
                if (serviceList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Service)), e);
                    return;
                }
            }
            List<object> ids = gridTransfer.GetSelectedFieldValues(gridTransfer.KeyFieldName);
            _transfer.Delete(ids);
            FinishGrid(e);
            gridTransfer.DataBind();
            gridTransfer.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }

        private void ErrorGrid(string way_name, string other_name, CancelEventArgs e)
        {
            string message = string.Format(Constants.strCannotDelete, way_name, other_name);
            gridTransfer.JSProperties[Constants.strCpMessage] = message;
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridTransfer.CancelEdit();
            gridTransfer.DataBind();
        }

        protected void gridTransfer_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
            var gridTransferDetail = grid.FindEditFormTemplateControl("gridTransferDetail") as SpecialLogisticsSystem.UserControl.ASPxGridView;
            if (!grid.IsNewRowEditing)
            {
                object id = grid.GetRowValues(grid.EditingRowVisibleIndex, grid.KeyFieldName);
                UpdateControll<T_Transfer_Main>.SetValueToControl(grid);
                List<T_Transfer_Detail> cList = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
                if (Session[strSeeionID] != null && id.ToString() != Session[strSeeionID].ToString())
                {
                    Session[Constants.TransferDetail] = null;
                    cList = null;
                }
                Session[strSeeionID] = id;
                if (cList == null)
                {
                    QueryInfo<T_Transfer_Detail> queryInfo = new QueryInfo<T_Transfer_Detail>();
                    queryInfo.SetQuery(T_Transfer_Detail.MainIdColumnName, id);
                    List<T_Transfer_Detail> productionList = _transfer_detail.GetList(queryInfo).ToList();
                    Session[Constants.TransferDetail] = productionList;
                }
                //gridTransferDetail.DataSource = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
                gridTransferDetail.DataBind();
            }
        }

        #endregion

        #region 运单信息

        protected void gridTransferDetail_Load(object sender, EventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            var id = grid.GetMasterRowKeyValue();
            QueryInfo<T_Transfer_Detail> queryInfo = new QueryInfo<T_Transfer_Detail>();
            queryInfo.SetQuery("main_id", id);
            grid.DataSource = _transfer_detail.Select(queryInfo);
            grid.DataBind();
        }

        protected void gridTransferDetail_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            if (e.VisibleIndex == -1)
                return;
            int index = e.VisibleIndex;
            List<T_Transfer_Detail> lists = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
            ASPxTextBox txtServiceNo = grid.FindRowCellTemplateControl(index, grid.Columns["service_no"] as GridViewDataColumn, "txtServiceNo") as ASPxTextBox;
            ASPxTextBox txtTransferBill = grid.FindRowCellTemplateControl(index, grid.Columns["transfer_bill"] as GridViewDataColumn, "txtTransferBill") as ASPxTextBox;
            txtServiceNo.Text = lists[index].service_no;
            txtTransferBill.Text = lists[index].transfer_bill.ToString();
        }


        protected void gridTransferDetail_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            if (e.Parameters == "Update")
            {
                for (int index = 0; index < grid.VisibleRowCount; index++)
                {
                    ASPxTextBox txtServiceNo = grid.FindRowCellTemplateControl(index, grid.Columns["service_no"] as GridViewDataColumn, "txtServiceNo") as ASPxTextBox;
                    ASPxTextBox txtTransferBill = grid.FindRowCellTemplateControl(index, grid.Columns["transfer_bill"] as GridViewDataColumn, "txtTransferBill") as ASPxTextBox;
                    Guid id = ConvertHelper.ObjectToGuid(grid.GetRowValues(index, "id")).Value;

                    List<T_Transfer_Detail> lists = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
                    lists.ForEach(a =>
                    {
                        if (a.id == id)
                        {
                            //a.production_id = production_id;
                            a.service_no = txtServiceNo.Text;
                            a.transfer_bill = ConvertHelper.ObjectToDecimal(txtTransferBill.Value);
                        }
                    });
                    Session[Constants.TransferDetail] = lists;
                    //gridStockManageDetail.DataSource = lists;
                }
            }
        }
        ///// <summary>
        ///// grid 没有caching 只能用这种绑定
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void gridTransferDetail_DataBinding(object sender, EventArgs e)
        //{
        //    var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
        //    grid.DataSource = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
        //}

        //private void BindDetail(SpecialLogisticsSystem.UserControl.ASPxGridView grid, CancelEventArgs e, List<T_Transfer_Detail> detailList)
        //{
        //    Session[Constants.TransferDetail] = detailList;
        //    e.Cancel = true;
        //    grid.CancelEdit();
        //    if (null == Session[Constants.TransferDetail]) return;
        //    grid.DataSource = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
        //    grid.DataBind();
        //    grid.JSProperties.Add("cp_strCalTotal", strCalTotal);
        //}
        ///// <summary>
        ///// 新增货物
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void gridTransferDetail_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        //{
        //    var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
        //    var detailList = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
        //    if (detailList == null) detailList = new List<T_Transfer_Detail>();
        //    T_Transfer_Detail model = new T_Transfer_Detail();
        //    UIHelpers.TryUpdateModel<T_Transfer_Detail>.ToUpdateModel(model, grid);
        //    model.id = Guid.NewGuid();
        //    detailList.Add(model);
        //    BindDetail(grid, e, detailList);
        //}
        ///// <summary>
        ///// 修改货物
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void gridTransferDetail_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        //{
        //    var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
        //    Guid gridId = ConvertHelper.ObjectToGuid(e.Keys[0]).Value;
        //    T_Transfer_Detail detail = _transfer_detail.GetSingle(e.Keys[0]);
        //    var detailList = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
        //    if (detailList == null) return;
        //    if (detail == null) detail = detailList.FirstOrDefault(p => p.id == gridId);
        //    UIHelpers.TryUpdateModel<T_Transfer_Detail>.ToUpdateModel(detail, grid);
        //    detailList.ForEach((p) =>
        //    {
        //        if (p.id == gridId)
        //        {
        //            p = detail;
        //        }
        //    });
        //    BindDetail(grid, e, detailList);
        //}
        ///// <summary>
        ///// 删除货物
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void gridTransferDetail_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        //{
        //    var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
        //    var deleteId = grid.GetSelectedFieldValues(grid.KeyFieldName).Select(p => ConvertHelper.ObjectToGuid(p));
        //    var roductionList = Session[Constants.TransferDetail] as List<T_Transfer_Detail>;
        //    if (roductionList == null) return;
        //    roductionList.RemoveAll((c) => { return deleteId.Contains(c.id); });
        //    BindDetail(grid, e, roductionList);
        //}
        ///// <summary>
        ///// 填充货物信息
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void gridTransferDetail_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        //{
        //    var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
        //    if (grid.IsNewRowEditing) return;
        //    UpdateControll<T_Transfer_Detail>.SetValueToControl(grid);
        //    //List<object> ids = grid.GetSelectedFieldValues(grid.KeyFieldName);
        //    //List<T_Way_Bill> ProductionList = Session[Constants.TransferDetail] as List<T_Way_Bill>;
        //    //if (ProductionList == null || ids.Count == 0) return;
        //    //var Production = ProductionList.FirstOrDefault(p => ids.Contains(p.id));
        //}
        #endregion
    }
}