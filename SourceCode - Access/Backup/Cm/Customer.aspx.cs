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
using Newtonsoft.Json;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Customer : BasePage<Customer>
    {
        [Dependency]
        public ICmCustomerDal _customer { get; set; }
        [Dependency]
        public ICmLinkDal _link { get; set; }
        [Dependency]
        public IWayBillDal _way { get; set; }

        private static string strLinkMan = "link_id";
        private static string strSessionName = "LinkMan";
        private static string strSeeionID = "id";

        protected void Page_Init(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null != Session[strSessionName])
                {
                    Session[strSessionName] = null;
                }
            }
        }

        #region 发货方
        private void BindData(string filter)
        {
            QueryInfo<T_Cm_Customer> queryInfo = new QueryInfo<T_Cm_Customer>();
            queryInfo.SetQuery(T_Cm_Customer.CustomerTypeColumnName, CustomerType.Deliver.ToString());
            if (!string.IsNullOrEmpty(filter))
            {
                Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
                queryInfo.SetQuery(query.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
            }
            gridCustomer.DataSource = _customer.Select(queryInfo);
            gridCustomer.DataBind();
        }

        private void BindData()
        {
            BindData(string.Empty);
        }

        private void ErrorGrid(string Customer_name, string other_name, CancelEventArgs e)
        {
            string message = string.Format("客户:【{0}】 被其他{1}引用，无法删除！", Customer_name, other_name);
            gridCustomer.JSProperties[Constants.strCpMessage] = message;
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridCustomer.CancelEdit();
            BindData();
        }

        protected void gridCustomer_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            Session[strSessionName] = null;
        }

        protected void gridCustomer_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            //1. 保存发货方 2. 保存收货方
            var linkMan = gridCustomer.FindEditFormTemplateControl("link_id") as LinkMan;
            T_Cm_Link link = linkMan.GetLink();
            T_Cm_Customer customer = new T_Cm_Customer();
            UIHelpers.TryUpdateModel<T_Cm_Customer>.ToUpdateModel(customer, gridCustomer);
            customer.id = Guid.NewGuid();
            customer.customer_type = CustomerType.Deliver.ToString();
            customer.link = link;
            _customer.Insert(customer);
            //收货方
            var consigneeList = Session[strSessionName] as List<T_Cm_Customer>;
            if (consigneeList != null)
            {
                consigneeList.ForEach((p) =>
                {
                    p.sender_id = customer.id;
                    _customer.Insert(p);
                });
                Session[strSessionName] = null;
            }
            FinishGrid(e);
        }

        protected void gridCustomer_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            var linkMan = gridCustomer.FindEditFormTemplateControl(strLinkMan) as LinkMan;
            T_Cm_Customer customer = _customer.GetSingle(e.Keys[0]);
            UIHelpers.TryUpdateModel<T_Cm_Customer>.ToUpdateModel(customer, gridCustomer);
            T_Cm_Link link = linkMan.GetLink();
            link.id = customer.link_id;
            customer.link = link;
            _customer.Update(customer);
            //收货方 先删除 后添加（因为不清楚是新增或修改）
            _customer.DeleteBySender(customer.id);
            var consigneeList = Session[strSessionName] as List<T_Cm_Customer>;
            if (consigneeList != null)
            {
                foreach (var item in consigneeList)
                {
                    item.sender_id = customer.id;
                    //item.id = Guid.NewGuid();
                    _customer.Insert(item);
                }
                Session[strSessionName] = null;
            }
            FinishGrid(e);
        }

        protected void gridCustomer_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> CustomerAndNames = gridCustomer.GetSelectedFieldValues(new string[] { gridCustomer.KeyFieldName, T_Cm_Customer.CustomerNameColumnName });
            foreach (object[] id_name in CustomerAndNames)
            {
                var id = id_name[0];
                var name = id_name[1].ToString();
                //与运单关联
                IList<T_Way_Bill> wayList = _way.GetList(new QueryInfo<T_Way_Bill>().SetQuery(T_Way_Bill.DeliverIDColumnName, id));
                if (wayList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Way_Bill)), e);
                    return;
                }
             
            }
            List<object> ids = gridCustomer.GetSelectedFieldValues(T_Cm_Customer.IDColumnName);
            List<object> link_ids = gridCustomer.GetSelectedFieldValues(T_Cm_Customer.LinkIDColumnName);
            _customer.Delete(link_ids,ids);
            FinishGrid(e);
            BindData();
            gridCustomer.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }

        protected void gridCustomer_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            UpdateControll<T_Cm_Customer>.SetValueToControl(grid);
            if (!grid.IsNewRowEditing)
            {
                object id = grid.GetRowValues(grid.EditingRowVisibleIndex, grid.KeyFieldName);
                List<T_Cm_Customer> cList = Session[strSessionName] as List<T_Cm_Customer>;
                if (Session[strSeeionID] != null && id.ToString() != Session[strSeeionID].ToString()) Session[strSessionName] = null;
                Session[strSeeionID] = id;
                if (Session[strSessionName] == null)
                {
                    QueryInfo<T_Cm_Customer> queryInfo = new QueryInfo<T_Cm_Customer>();
                    queryInfo.SetQuery(T_Cm_Customer.CustomerTypeColumnName, CustomerType.Consignee.ToString());
                    queryInfo.SetQuery(T_Cm_Customer.SenderIdColumnName, id);
                    List<T_Cm_Customer> customerList = _customer.GetList(queryInfo).ToList();
                    foreach (var item in customerList)
                    {
                        T_Cm_Link link = _link.GetSingle(item.link_id);
                        item.link = link;
                    }
                    Session[strSessionName] = customerList;
                }
                var gridConsignee = grid.FindEditFormTemplateControl("gridConsignee") as ASPxGridView;
                gridConsignee.DataSource = Session[strSessionName] as List<T_Cm_Customer>;
                gridConsignee.DataBind();
            }
        }

        protected void gridCustomer_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            if (e.CallbackName == "APPLYFILTER")
            {
                //Session.Add("cp_filter", e.Args[0]);
                BindData(e.Args[0]);
            }
        }
        #endregion

        #region 收货方信息
        /// <summary>
        /// grid 没有caching 只能用这种绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridConsignee_DataBinding(object sender, EventArgs e)
        {
            var grid = sender as ASPxGridView;
            grid.DataSource = Session[strSessionName] as List<T_Cm_Customer>;
        }

        private void BindConsignee(ASPxGridView grid, CancelEventArgs e, List<T_Cm_Customer> consigneeList)
        {
            Session[strSessionName] = consigneeList;
            e.Cancel = true;
            grid.CancelEdit();
            if (null == Session[strSessionName]) return;
            grid.DataSource = Session[strSessionName] as List<T_Cm_Customer>;
            grid.DataBind();
        }
        /// <summary>
        /// 新增收货人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridConsignee_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var link_man = grid.FindEditFormTemplateControl(strLinkMan) as LinkMan;
            var consigneeList = Session[strSessionName] as List<T_Cm_Customer>;
            if (consigneeList == null) consigneeList = new List<T_Cm_Customer>();
            T_Cm_Customer model = new T_Cm_Customer();
            model.id = Guid.NewGuid();
            model.customer_type = CustomerType.Consignee.ToString();
            model.link = link_man.GetLink();
            model.customer_name = model.link.link_name;
            consigneeList.Add(model);
            BindConsignee(grid, e, consigneeList);
        }
        /// <summary>
        /// 修改收货人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridConsignee_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var link_man = grid.FindEditFormTemplateControl(strLinkMan) as LinkMan;
            var consigneeList = Session[strSessionName] as List<T_Cm_Customer>;
            if (consigneeList == null) return;
            consigneeList.ForEach((p) =>
            {
                if (p.id == ConvertHelper.ObjectToGuid(e.Keys["id"]))
                {
                    p.link = link_man.GetLink();
                }
            });
            BindConsignee(grid, e, consigneeList);
        }
        /// <summary>
        /// 删除收货人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridConsignee_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var deleteId = grid.GetSelectedFieldValues(grid.KeyFieldName).Select(p => ConvertHelper.ObjectToGuid(p));
            var consigneeList = Session[strSessionName] as List<T_Cm_Customer>;
            if (consigneeList == null) return;
            consigneeList.RemoveAll((c) => { return deleteId.Contains(c.id); });
            BindConsignee(grid, e, consigneeList);
        }
        /// <summary>
        /// 填充收货人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridConsignee_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            if (grid.IsNewRowEditing) return;
            var link_man = grid.FindEditFormTemplateControl(strLinkMan) as LinkMan;
            List<object> ids = grid.GetSelectedFieldValues(grid.KeyFieldName);
            List<T_Cm_Customer> consigneeList = Session[strSessionName] as List<T_Cm_Customer>;
            if (consigneeList == null || ids.Count == 0) return;
            var consignee = consigneeList.FirstOrDefault(p => ids.Contains(p.id));
            link_man.SetData(consignee.link);
        }
        #endregion
    }
}