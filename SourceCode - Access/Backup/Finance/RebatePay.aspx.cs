using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Data;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using DevExpress.Web.ASPxEditors;

namespace SpecialLogisticsSystem.AppPortal.Finance
{
    public partial class RebatePay : BasePage<RebatePay>
    {
        [Dependency]
        public IWayBillDal _way { get; set; }
        [Dependency]
        public IFinanceDiscountDal _finance_discount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.DiscountPay;
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
                UpdateControll<T_Finance_Discount>.SetValueToControl(grid);
                ASPxTextBox bill_rebate = grid.FindEditFormTemplateControl("bill_rebate") as ASPxTextBox;
                ASPxTextBox settle_money = grid.FindEditFormTemplateControl("settle_money") as ASPxTextBox;
                settle_money.Text = bill_rebate.Text;
                //SpecialLogisticsSystem.UserControl.ASPxTextBox aggregate_amount =
                //    grid.FindEditFormTemplateControl(T_Finance_Discount.AggregateAmountColumnName) as SpecialLogisticsSystem.UserControl.ASPxTextBox;
                //SpecialLogisticsSystem.UserControl.ASPxTextBox settle_accounts =
                //    grid.FindEditFormTemplateControl(T_Finance_Discount.SettleAccountsColumnName) as SpecialLogisticsSystem.UserControl.ASPxTextBox;
                //settle_accounts.Text = aggregate_amount.Text;
                //SpecialLogisticsSystem.UserControl.ASPxTextBox real_payment =
                //  grid.FindEditFormTemplateControl(T_Finance_Discount.RealPaymentColumnName) as SpecialLogisticsSystem.UserControl.ASPxTextBox;
                //real_payment.Text = settle_accounts.Text;
                //EmployeeLookUp operator_man = grid.FindEditFormTemplateControl(T_Finance_Discount.OperatorColumnName) as EmployeeLookUp;
                //operator_man.IsSetDefault = true;
            }
        }

        protected void gridWay_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Finance_Discount finance_discount = new T_Finance_Discount();
            finance_discount.id = Guid.NewGuid();
            UIHelpers.TryUpdateModel<T_Finance_Discount>.ToUpdateModel(finance_discount, gridWay);
            finance_discount.way_id = ConvertHelper.ObjectToGuid(e.Keys[0]).Value;
            finance_discount.branch_id = UserProvide.GetCurrentBranchID();
            _finance_discount.Insert(finance_discount);
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