using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.Data;
using System.ComponentModel;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using Newtonsoft.Json;
using System.Linq;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Employee : BasePage<Employee>
    {
        [Dependency]
        public ICmEmpDal _employee { get; set; }
        [Dependency]
        public ICmUserDal _user { get; set; }
        [Dependency]
        public ICmCustomerDal _customer { get; set; }
        [Dependency]
        public IWayBillDal _way { get; set; }
        [Dependency]
        public IStowageMainDal _stowage { get; set; }
        [Dependency]
        public ITransferMainDal _transfer { get; set; }
        [Dependency]
        public IArrivalDeliverDal _arrival_deliver { get; set; }
        [Dependency]
        public IArrivalMainDal _arrival { get; set; }
        [Dependency]
        public IArrivalSignDal _sign { get; set; }
        [Dependency]
        public IFinanceCustomerDal _finance_customer { get; set; }
        [Dependency]
        public IFinanceDriverDal _finance_driver { get; set; }
        [Dependency]
        public IFinanceServiceDal _finance_service { get; set; }
        [Dependency]
        public IFinanceDiscountDal _finance_discount { get; set; }
        [Dependency]
        public IFinanceDailyDal _finance_daily { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BindData()
        {
            var queryInfo = new QueryInfo<T_Cm_Emp>();
            if (Session["cp_filter"] != null)
            {
                Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(Session["cp_filter"].ToString());
                queryInfo.SetQuery(query.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
            }
            gridEmployee.DataSource = _employee.Select(queryInfo);
            gridEmployee.DataBind();
        }

        protected void gridEmployee_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            T_Cm_Emp employee = new T_Cm_Emp();
            UIHelpers.TryUpdateModel<T_Cm_Emp>.ToUpdateModel(employee, gridEmployee);
            employee.id = Guid.NewGuid();
            _employee.Insert(employee);
            FinishGrid(e);
        }

        protected void gridEmployee_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Cm_Emp employee = _employee.GetSingle(e.Keys[0]);
            UIHelpers.TryUpdateModel<T_Cm_Emp>.ToUpdateModel(employee, gridEmployee);
            employee.update_date = DateTime.Now;
            employee.add_date = DateTime.Now;
            _employee.Update(employee);
            FinishGrid(e);
        }

        protected void gridEmployee_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> idAndNames = gridEmployee.GetSelectedFieldValues(new string[] { gridEmployee.KeyFieldName, T_Cm_Emp.EmpNameColumnName });
            foreach (object[] id_name in idAndNames)
            {
                var id = id_name[0];
                var name = id_name[1].ToString();
                //与用户关联
                IList<T_Cm_User> userList = _user.GetList(new QueryInfo<T_Cm_User>().SetQuery(T_Cm_User.EmpIdColumnName, id));
                if (userList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Cm_User)), e);
                    return;
                }
                //与客户资料关联
                IList<T_Cm_Customer> customerList = _customer.GetList(new QueryInfo<T_Cm_Customer>().SetQuery(T_Cm_Customer.EmpIDColumnName, id));
                if (customerList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Cm_Customer)), e);
                    return;
                }
                //与托运单关联
                IList<T_Way_Bill> wayList = _way.GetList(new QueryInfo<T_Way_Bill>().SetQuery(T_Way_Bill.EmpIDColumnName, id));
                if (wayList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Way_Bill)), e);
                    return;
                }
                //与配载发车关联
                IList<T_Stowage_Main> stowageList = _stowage.GetList(new QueryInfo<T_Stowage_Main>().SetQuery(T_Stowage_Main.EmpIDColumnName, id));
                if (stowageList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Stowage_Main)), e);
                    return;
                }
                //与中转外包关联
                IList<T_Transfer_Main> transferList = _transfer.GetList(new QueryInfo<T_Transfer_Main>().SetQuery(T_Transfer_Main.EmpIDColumnName, id));
                if (transferList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Transfer_Main)), e);
                    return;
                }
                //与到货管理关联
                IList<T_Arrival_Main> arrivalList = _arrival.GetList(new QueryInfo<T_Arrival_Main>().SetQuery(T_Arrival_Main.EmpIDColumnName, id));
                if (arrivalList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Arrival_Main)), e);
                    return;
                }
                //与送货管理关联
                IList<T_Arrival_Deliver> deliverList = _arrival_deliver.GetList(new QueryInfo<T_Arrival_Deliver>().SetQuery(T_Arrival_Deliver.EmpIDColumnName, id));
                if (deliverList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Arrival_Deliver)), e);
                    return;
                }
                //与签收关联
                IList<T_Arrival_Sign> signList = _sign.GetList(new QueryInfo<T_Arrival_Sign>().SetQuery(T_Arrival_Sign.EmpIDColumnName, id));
                if (signList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Arrival_Sign)), e);
                    return;
                }
                //客户结算关联
                IList<T_Finance_Customer> financeCustomerList = _finance_customer.GetList(new QueryInfo<T_Finance_Customer>().SetQuery(T_Finance_Customer.EmpIDColumnName, id));
                if (financeCustomerList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Customer)), e);
                    return;
                }
                //司机结算
                IList<T_Finance_Driver> driverList = _finance_driver.GetList(new QueryInfo<T_Finance_Driver>().SetQuery(T_Finance_Driver.EmpIDColumnName, id));
                if (driverList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Driver)), e);
                    return;
                }
                //服务商结算
                IList<T_Finance_Service> serviceList = _finance_service.GetList(new QueryInfo<T_Finance_Service>().SetQuery(T_Finance_Service.EmpIDColumnName, id));
                if (serviceList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Service)), e);
                    return;
                }
                //日常结算
                IList<T_Finance_Daily> dailyList = _finance_daily.GetList(new QueryInfo<T_Finance_Daily>().SetQuery(T_Finance_Daily.EmpIDColumnName, id));
                if (dailyList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Daily)), e);
                    return;
                }
                //回扣发放
                IList<T_Finance_Discount> discountList = _finance_discount.GetList(new QueryInfo<T_Finance_Discount>().SetQuery(T_Finance_Discount.EmpIDColumnName, id));
                if (discountList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Discount)), e);
                    return;
                }
            }
            List<object> ids = gridEmployee.GetSelectedFieldValues(gridEmployee.KeyFieldName);
            _employee.Delete(ids);
            FinishGrid(e);
            BindData();
            gridEmployee.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }

        private void ErrorGrid(string name, string other_name, CancelEventArgs e)
        {
            string message = string.Format(Constants.strCannotDelete, name, other_name);
            gridEmployee.JSProperties[Constants.strCpMessage] = message;
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridEmployee.CancelEdit();
            BindData();
        }
        protected void gridEmployee_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            //var emp_no = grid.FindEditFormTemplateControl("emp_no") as ASPxLabel;       
            UpdateControll<T_Cm_Emp>.SetValueToControl(grid);
            //if (grid.IsNewRowEditing)
            //{
            //    emp_no.Value = _number.GetNumber(CodeTable.Emp);
            //}
        }
        protected void gridEmployee_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            if (e.CallbackName == "APPLYFILTER")
            {
                Session.Add("cp_filter", e.Args[0]);
                BindData();
            }
        }
    }
}