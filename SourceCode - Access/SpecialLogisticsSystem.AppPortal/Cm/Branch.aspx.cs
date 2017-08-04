using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Data;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.AppPortal.UserControls;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Branch : BasePage<Branch>
    {
        [Dependency]
        public ICmBranchDal _branch { get; set; }
        [Dependency]
        public ICmLinkDal _link { get; set; }
        [Dependency]
        public ICmUserBranchRelationDal _user_branch { get; set; }
        [Dependency]
        public ICmUserDal _user { get; set; }
        [Dependency]
        public ICmEmpDal _emp { get; set; }
        [Dependency]
        public ICmCarDal _car { get; set; }
        [Dependency]
        public IStowageMainDal _stowage { get; set; }
        [Dependency]
        public IArrivalDeliverDal _arrival { get; set; }
        [Dependency]
        public IFinanceCustomerDal _finance_customer { get; set; }
        [Dependency]
        public IFinanceDailyDal _finance_daily { get; set; }
        [Dependency]
        public IFinanceDiscountDal _finance_discount { get; set; }
        [Dependency]
        public IFinanceDriverDal _finance_driver { get; set; }
        [Dependency]
        public IFinanceServiceDal _finance_service { get; set; }

        private const string link_id = "link_id";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.IsShowSearch = false;
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            BindData();
        }


        private void BindData()
        {
            gridBranch.DataSource = _branch.Select(new QueryInfo<T_Cm_Branch>());
            gridBranch.DataBind();
        }

        protected void gridBranch_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            var linkMan = gridBranch.FindEditFormTemplateControl(link_id) as LinkMan;
            T_Cm_Link link = linkMan.GetLink();
            T_Cm_Branch branch = new T_Cm_Branch();
            UIHelpers.TryUpdateModel<T_Cm_Branch>.ToUpdateModel(branch, gridBranch);
            branch.id = Guid.NewGuid();
            branch.link_id = link.id;
            _branch.Insert(branch);
            _link.Insert(link);
            e.Cancel = true;
            gridBranch.CancelEdit();
            BindData();
        }

        protected void gridBranch_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            var linkMan = gridBranch.FindEditFormTemplateControl(link_id) as LinkMan;
            T_Cm_Link link = linkMan.GetLink();
            T_Cm_Branch branch = _branch.GetSingle(e.Keys[0]);
            link.id = branch.link_id;
            UIHelpers.TryUpdateModel<T_Cm_Branch>.ToUpdateModel(branch, gridBranch);
            _branch.Update(branch);
            T_Cm_Link oldLink= _link.GetSingle(branch.link_id);
            if (null != oldLink)
            {
                _link.Update(link);
            }
            else
            {
                _link.Insert(link);
            }
            e.Cancel = true;
            gridBranch.CancelEdit();
            BindData();
        }

        protected void gridBranch_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> branchAndNames = gridBranch.GetSelectedFieldValues(new string[] { T_Cm_Branch.IdColumnName, T_Cm_Branch.NameColumnName });
            foreach (object[] branch_id_name in branchAndNames)
            {
                var branch_id = branch_id_name[0];
                var branch_name = branch_id_name[1].ToString();
                //与员工关联
                IList<T_Cm_Emp> empList = _emp.GetList(new QueryInfo<T_Cm_Emp>().SetQuery(T_Cm_Emp.BranchIDColumnName, branch_id));
                if (empList.Count > 0)
                {
                    ErrorGrid(branch_name,AttributesHelper.GetDisplayNameAttributes(typeof(T_Cm_Emp)), e);
                    return;
                }
                //与用户关联
                IList<T_Cm_UserBranch_Relation> userBranchList = _user_branch.GetList(new QueryInfo<T_Cm_UserBranch_Relation>().SetQuery(T_Cm_Emp.BranchIDColumnName, branch_id));
                IList<T_Cm_User> userList = _user.GetList(new QueryInfo<T_Cm_User>().SetQuery(T_Cm_Emp.BranchIDColumnName, branch_id));
                if (userList.Count > 0 || userBranchList.Count > 0)
                {
                    ErrorGrid(branch_name,AttributesHelper.GetDisplayNameAttributes(typeof(T_Cm_User)), e);
                    return;
                }
                //与车辆司机关联
                IList<T_Cm_Car> carList = _car.GetList(new QueryInfo<T_Cm_Car>().SetQuery(T_Cm_Emp.BranchIDColumnName, branch_id));
                if (carList.Count > 0)
                {
                    ErrorGrid(branch_name,AttributesHelper.GetDisplayNameAttributes(typeof(T_Cm_Car)), e);
                    return;
                }
                //与配载发车关联
                IList<T_Stowage_Main> startStowageList = _stowage.GetList(new QueryInfo<T_Stowage_Main>().SetQuery(T_Stowage_Main.StartBranchColumnName, branch_id));
                if (startStowageList.Count > 0)
                {
                    ErrorGrid(branch_name,AttributesHelper.GetDisplayNameAttributes(typeof(T_Stowage_Main)), e);
                    return;
                }
                IList<T_Stowage_Main> endStowageList = _stowage.GetList(new QueryInfo<T_Stowage_Main>().SetQuery(T_Stowage_Main.EndBranchColumnName, branch_id));
                if (endStowageList.Count > 0)
                {
                    ErrorGrid(branch_name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Stowage_Main)), e);
                    return;
                }
                //送货信息关联
                IList<T_Arrival_Deliver> arrivalList = _arrival.GetList(new QueryInfo<T_Arrival_Deliver>().SetQuery(T_Arrival_Deliver.BranchIdColumnName, branch_id));
                if (arrivalList.Count > 0)
                {
                    ErrorGrid(branch_name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Arrival_Deliver)), e);
                    return;
                }
                //客户结算关联
                IList<T_Finance_Customer> customerList = _finance_customer.GetList(new QueryInfo<T_Finance_Customer>().SetQuery(T_Finance_Customer.BranchIdColumnName, branch_id));
                if (customerList.Count > 0)
                {
                    ErrorGrid(branch_name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Customer)), e);
                    return;
                }
                //司机结算
                IList<T_Finance_Driver> driverList = _finance_driver.GetList(new QueryInfo<T_Finance_Driver>().SetQuery(T_Finance_Driver.BranchIdColumnName, branch_id));
                if (driverList.Count > 0)
                {
                    ErrorGrid(branch_name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Driver)), e);
                    return;
                }
                //服务商结算
                IList<T_Finance_Service> serviceList = _finance_service.GetList(new QueryInfo<T_Finance_Service>().SetQuery(T_Finance_Service.BranchIdColumnName, branch_id));
                if (serviceList.Count > 0)
                {
                    ErrorGrid(branch_name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Service)), e);
                    return;
                }
                //日常结算
                IList<T_Finance_Daily> dailyList = _finance_daily.GetList(new QueryInfo<T_Finance_Daily>().SetQuery(T_Finance_Daily.BranchIdColumnName, branch_id));
                if (dailyList.Count > 0)
                {
                    ErrorGrid(branch_name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Daily)), e);
                    return;
                }
                //回扣发放
                IList<T_Finance_Discount> discountList = _finance_discount.GetList(new QueryInfo<T_Finance_Discount>().SetQuery(T_Finance_Discount.BranchIdColumnName, branch_id));
                if (discountList.Count > 0)
                {
                    ErrorGrid(branch_name,AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Discount)), e);
                    return;
                }
            }
            //先删除联系人
            List<object> linkIds = gridBranch.GetSelectedFieldValues(T_Cm_Branch.LinkIdColumnName);
            _link.Delete(linkIds);
            List<object> branchIds = gridBranch.GetSelectedFieldValues(T_Cm_Branch.IdColumnName);
            _branch.Delete(branchIds);
            FinishGrid(e);
            BindData();
            gridBranch.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }

        private void ErrorGrid(string branch_name,string other_name, CancelEventArgs e)
        {
            string message = string.Format(Constants.strCannotDelete, branch_name, other_name);
            gridBranch.JSProperties[Constants.strCpMessage] = message;
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridBranch.CancelEdit();
        }

        protected void gridBranch_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            UpdateControll<T_Cm_Branch>.SetValueToControl(grid);
        }
    }
}