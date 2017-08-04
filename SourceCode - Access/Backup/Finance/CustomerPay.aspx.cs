using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using DevExpress.Web.Data;
using System.ComponentModel;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.AppPortal.UserControls;

namespace SpecialLogisticsSystem.AppPortal.Finance
{
    public partial class CustomerPay : BasePage<CustomerPay>
    {
        [Dependency]
        public IWayBillDal _way { get; set; }
        [Dependency]
        public IFinanceCustomerDal _finance_customer { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.CustomerPay;
                }
            }
        }

        protected void gridWay_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> ids = gridWay.GetSelectedFieldValues(gridWay.KeyFieldName);
            switch (e.Parameters)
            {
                default:
                    break;
            }
            gridWay.DataBind();
        }

        protected void gridWay_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            if (!grid.IsNewRowEditing)
            {
                object id = grid.GetRowValues(grid.EditingRowVisibleIndex, grid.KeyFieldName);
                UpdateControll<T_Finance_Customer>.SetValueToControl(grid);
                SpecialLogisticsSystem.UserControl.ASPxTextBox aggregate_amount = 
                    grid.FindEditFormTemplateControl(T_Finance_Customer.AggregateAmountColumnName) as SpecialLogisticsSystem.UserControl.ASPxTextBox;
                SpecialLogisticsSystem.UserControl.ASPxTextBox settle_accounts =
                    grid.FindEditFormTemplateControl(T_Finance_Customer.SettleAccountsColumnName) as SpecialLogisticsSystem.UserControl.ASPxTextBox;
                settle_accounts.Text = aggregate_amount.Text;
                SpecialLogisticsSystem.UserControl.ASPxTextBox real_payment =
                  grid.FindEditFormTemplateControl(T_Finance_Customer.RealPaymentColumnName) as SpecialLogisticsSystem.UserControl.ASPxTextBox;
                real_payment.Text = settle_accounts.Text;
                //EmployeeLookUp operator_man = grid.FindEditFormTemplateControl(T_Finance_Customer.OperatorColumnName) as EmployeeLookUp;
                //operator_man.IsSetDefault = true;
            }
        }

        protected void gridWay_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Finance_Customer finance_customer = new T_Finance_Customer();
            finance_customer.id = Guid.NewGuid();
            UIHelpers.TryUpdateModel<T_Finance_Customer>.ToUpdateModel(finance_customer, gridWay);
            finance_customer.way_id = ConvertHelper.ObjectToGuid(e.Keys[0]).Value;
            finance_customer.branch_id = UserProvide.GetCurrentBranchID();
            _finance_customer.Insert(finance_customer);
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridWay.CancelEdit();
        }

        protected void wayDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridWay.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridWay.FilterExpression) ? gridWay.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}