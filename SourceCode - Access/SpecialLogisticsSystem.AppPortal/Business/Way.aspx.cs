using System;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Data;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;
using SpecialLogisticsSystem.AppPortal.UserControls;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.Web.ASPxGridLookup;
using System.Web.UI.WebControls;

namespace SpecialLogisticsSystem.AppPortal.Business
{
    public partial class Way : BasePage<Way>
    {
        [Dependency]
        public IWayBillDal _way { get; set; }
        [Dependency]
        public IWayProductionDal _production { get; set; }
        [Dependency]
        public ICmCustomerDal _customer { get; set; }
        [Dependency]
        public ICmLinkDal _link { get; set; }

        //private static string strCalTotal = "CalTotal";
        private static string strSeeionID = "id";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.Way;
                }
                if (null != Session[Constants.ProductionDetail])
                {
                    Session[Constants.ProductionDetail] = null;
                }
            }
        }

        #region 托运单

        protected void gridWayDetail_Load(object sender, EventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            var bill_id = grid.GetMasterRowKeyValue();
            QueryInfo<T_Way_Production> queryInfo = new QueryInfo<T_Way_Production>();
            queryInfo.SetQuery("bill_id", bill_id);
            grid.DataSource = _production.GetList(queryInfo);
            grid.DataBind();
        }

        protected void gridWay_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> ids = gridWay.GetSelectedFieldValues(gridWay.KeyFieldName);
            switch (e.Parameters)
            {
                case "instorage":
                    UpdateStatue(ids, WayStatue.Storage);
                    break;
                case "outstorage":
                    UpdateStatue(ids, WayStatue.New);
                    break;
                default:
                    break;
            }
            gridWay.DataBind();
        }

        private void UpdateStatue(List<object> ids, WayStatue statue)
        {
            foreach (var id in ids)
            {
                T_Way_Bill way = _way.GetSingle(id);
                way.bill_statue = statue.ToString();
                _way.Update(way);
            }
        }

        protected void wayDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            //if (gridWay.IsCallback || !IsPostBack)
            //{
            if (!string.IsNullOrEmpty(gridWay.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridWay.FilterExpression) ? gridWay.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        private void ErrorGrid(CancelEventArgs e)
        {
            string message = "运单非新建状态，无法作废！";
            gridWay.JSProperties[Constants.strCpMessage] = message;
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridWay.CancelEdit();
            gridWay.DataBind();
        }

        protected void gridWay_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            Session[Constants.ProductionDetail] = null;
        }

        protected void gridWay_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            //1. 更新发货人，收货人信息 2. 保存托运单 3. 保存货物
            var ProductionList = Session[Constants.ProductionDetail] as List<T_Way_Production>;
            if (ProductionList == null) { FinishGrid(e); return; }
            T_Way_Bill way = new T_Way_Bill();
            UIHelpers.TryUpdateModel<T_Way_Bill>.ToUpdateModel(way, gridWay);

            //保存发货人
            Guid deliver_id = InsertOrUpdateCustomer(way.deliver_id, way.deliver_name, way.deliver_mobile,
                way.deliver_area, way.deliver_address, CustomerType.Deliver, null);
            way.deliver_id = deliver_id;
            //保存收货人
            Guid consignee_id = InsertOrUpdateCustomer(way.consignee_id, way.consignee_name, way.consignee_mobile,
                way.consignee_area, way.consignee_address, CustomerType.Consignee, deliver_id);
            way.consignee_id = consignee_id;


            way.id = Guid.NewGuid();
            way.bill_statue = WayStatue.New.ToString();
            way.emp_id = UserProvide.GetCurrentEmpId().Value;
            way.aggregate_amount = ProductionList.Sum(p => p.freight);
            _way.Insert(way);
            //货物
            ProductionList.ForEach((p) =>
            {
                p.bill_id = way.id;
                _production.Insert(p);
            });
            Session[Constants.ProductionDetail] = null;

            FinishGrid(e);
            gridWay.JSProperties[Constants.strCpShowPopup] = "/Print/PrintWay.aspx?id=" + way.id.ToString();
        }

        private Guid InsertOrUpdateCustomer(Guid? id, string name, string mobile
            , string area, string address, CustomerType type, Guid? sendID)
        {
            bool IsAdd = !id.HasValue;
            Guid deliverID = IsAdd ? Guid.NewGuid() : id.Value;
            T_Cm_Customer customer = new T_Cm_Customer();
            customer.id = deliverID;
            T_Cm_Link link = new T_Cm_Link();
            link.id = Guid.NewGuid();
            if (!IsAdd)
            {
                customer = _customer.GetSingle(id);
                link = _link.GetSingle(customer.link_id);
            }
            customer.customer_type = type.ToString();
            customer.customer_name = name;

            if (sendID.HasValue)
                customer.sender_id = sendID.Value;

            link.link_name = name;
            link.link_address = address;
            link.link_area = area;
            link.link_mobilephone = mobile;
            customer.link = link;
            customer.create_date = DateTime.Now;
            if (IsAdd)
            {
                _customer.Insert(customer);
            }
            else
            {
                _customer.Update(customer);
            }
            return deliverID;
        }

        protected void gridWay_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            var ProductionList = Session[Constants.ProductionDetail] as List<T_Way_Production>;
            T_Way_Bill way = _way.GetSingle(e.Keys[0]);
            UIHelpers.TryUpdateModel<T_Way_Bill>.ToUpdateModel(way, gridWay);

            //保存发货人
            Guid deliver_id = InsertOrUpdateCustomer(way.deliver_id, way.deliver_name, way.deliver_mobile,
                way.deliver_area, way.deliver_address, CustomerType.Deliver, null);
            way.deliver_id = deliver_id;
            //保存收货人
            Guid consignee_id = InsertOrUpdateCustomer(way.consignee_id, way.consignee_name, way.consignee_mobile,
                way.consignee_area, way.consignee_address, CustomerType.Consignee, deliver_id);
            way.consignee_id = consignee_id;

            if (ProductionList != null)
            {
                way.aggregate_amount = ProductionList.Sum(p => p.freight);
            }
            _way.Update(way);
            //货物 先删除 后添加（因为不清楚是新增或修改）
            _production.DeleteByWay(way.id);
            if (ProductionList != null)
            {
                foreach (var item in ProductionList)
                {
                    item.bill_id = way.id;
                    _production.Insert(item);
                }
                Session[Constants.ProductionDetail] = null;
            }
            FinishGrid(e);
        }

        protected void gridWay_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            string strReturn = "作废成功！";
            List<object> wayIdsAndStatue = gridWay.GetSelectedFieldValues(new string[] { gridWay.KeyFieldName, "bill_statue" });
            foreach (object[] way in wayIdsAndStatue)
            {
                var wayId = way[0];
                var wayStatue = way[1].ToString();
                if (wayStatue != WayStatue.New.ToString())
                {
                    ErrorGrid(e);
                    return;
                }
            }
            List<object> wayIds = gridWay.GetSelectedFieldValues(gridWay.KeyFieldName);
            foreach (var wayid in wayIds)
            {
                T_Way_Bill way = _way.GetSingle(wayid);
                way.is_hide = true;
                _way.Update(way);
            }
            FinishGrid(e);
            gridWay.DataBind();
            gridWay.JSProperties[Constants.strCpMessage] = strReturn;
        }

        protected void gridWay_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            //var deliver_id = grid.FindEditFormTemplateControl("deliver_id") as ASPxGridLookup;
            //QueryInfo<T_Cm_Customer> queryInfo = new QueryInfo<T_Cm_Customer>();
            //queryInfo.SetQuery(T_Cm_Customer.CustomerTypeColumnName, CustomerType.Deliver.ToString());
            //deliver_id.DataSource = _customer.Select(queryInfo);
            //deliver_id.DataBind();
            var gridProduction = grid.FindEditFormTemplateControl("gridProduction") as SpecialLogisticsSystem.UserControl.ASPxGridView;
            if (!grid.IsNewRowEditing)
            {
                object id = grid.GetRowValues(grid.EditingRowVisibleIndex, grid.KeyFieldName);
                UpdateControll<T_Way_Bill>.SetValueToControl(grid);
                List<T_Way_Production> cList = Session[Constants.ProductionDetail] as List<T_Way_Production>;
                if (Session[strSeeionID] != null && id.ToString() != Session[strSeeionID].ToString()) Session[Constants.ProductionDetail] = null;
                Session[strSeeionID] = id;
                if (cList == null || cList.Count == 0)
                {
                    QueryInfo<T_Way_Production> queryInfo = new QueryInfo<T_Way_Production>();
                    queryInfo.SetQuery(T_Way_Production.BillIdColumnName, id);
                    List<T_Way_Production> productionList = _production.GetList(queryInfo).ToList();
                    Session[Constants.ProductionDetail] = productionList;
                }
                gridProduction.DataSource = Session[Constants.ProductionDetail] as List<T_Way_Bill>;
                gridProduction.DataBind();
                gridProduction.StartEdit(0);
            }
            else
            {
                gridProduction.AddNewRow();
            }
        }

        #endregion

        #region 货物信息
        /// <summary>
        /// grid 没有caching 只能用这种绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_DataBinding(object sender, EventArgs e)
        {
            var grid = sender as ASPxGridView;
            grid.DataSource = Session[Constants.ProductionDetail] as List<T_Way_Production>;
        }

        private void BindProduction(ASPxGridView grid, CancelEventArgs e, List<T_Way_Production> ProductionList)
        {
            Session[Constants.ProductionDetail] = ProductionList;
            e.Cancel = true;
            grid.CancelEdit();
            if (null == Session[Constants.ProductionDetail]) return;
            //grid.DataSource = Session[strSessionName] as List<T_Way_Production>;
            grid.DataBind();
            grid.JSProperties[Constants.strCpFinish] = "true";
            //grid.JSProperties.Add("cp_strCalTotal", strCalTotal);
        }
        /// <summary>
        /// 新增货物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var productionList = Session[Constants.ProductionDetail] as List<T_Way_Production>;
            if (productionList == null) productionList = new List<T_Way_Production>();
            T_Way_Production model = new T_Way_Production();
            UIHelpers.TryUpdateModel<T_Way_Production>.ToInsertModel(model, e);
            model.id = Guid.NewGuid();
            productionList.Add(model);
            BindProduction(grid, e, productionList);

        }
        /// <summary>
        /// 修改货物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            Guid gridId = ConvertHelper.ObjectToGuid(e.Keys[0]).Value;
            T_Way_Production production = _production.GetSingle(e.Keys[0]);
            var oldProductionList = Session[Constants.ProductionDetail] as List<T_Way_Production>;
            if (oldProductionList == null) return;
            if (production == null) production = oldProductionList.FirstOrDefault(p => p.id == gridId);
            UIHelpers.TryUpdateModel<T_Way_Production>.ToUpdateModel(production, e);
            var newProductionList = new List<T_Way_Production>();
            foreach (var item in oldProductionList)
            {
                if (item.id == gridId)
                {
                    newProductionList.Add(production);
                }
                else
                {
                    newProductionList.Add(item);
                }
            }
            BindProduction(grid, e, newProductionList);
        }
        /// <summary>
        /// 删除货物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var deleteId = grid.GetSelectedFieldValues(grid.KeyFieldName).Select(p => ConvertHelper.ObjectToGuid(p));
            var roductionList = Session[Constants.ProductionDetail] as List<T_Way_Production>;
            if (roductionList == null) return;
            roductionList.RemoveAll((c) => { return deleteId.Contains(c.id); });
            BindProduction(grid, e, roductionList);
        }
        /// <summary>
        /// 填充货物信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            if (grid.IsNewRowEditing) return;
            UpdateControll<T_Way_Production>.SetValueToControl(grid);
            //List<object> ids = grid.GetSelectedFieldValues(grid.KeyFieldName);
            //List<T_Way_Bill> ProductionList = Session[Constants.ProductionDetail] as List<T_Way_Bill>;
            //if (ProductionList == null || ids.Count == 0) return;
            //var Production = ProductionList.FirstOrDefault(p => ids.Contains(p.id));
        }

        protected void gridProduction_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            //var grid = sender as ASPxGridView;
            //decimal totalPrice = 0;
            //if (e.Parameters == strCalTotal)
            //{
            //    var aggregate_amount = gridWay.FindEditFormTemplateControl("aggregate_amount") as UserControl.ASPxTextBox;//总金额
            //    if (aggregate_amount == null) return;
            //    var productionList = Session[Constants.ProductionDetail] as List<T_Way_Production>;
            //    if (productionList != null)
            //    {
            //        //上保险所交的钱是保费,发生保险责任所赔偿的是保险合同成立时约定的保险金额也就是保额
            //        foreach (var item in productionList)
            //        {
            //            totalPrice += item.agency_fund + item.premium + item.delivery_expense + item.freight + item.other_expenses;
            //        }

            //    }
            //    aggregate_amount.Text = totalPrice.ToString();
            //}
        }
        #endregion
    }
}