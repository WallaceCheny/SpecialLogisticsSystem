using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.ASPxGridView;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.Tool;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using DevExpress.Web.Data;
using System.ComponentModel;

namespace SpecialLogisticsSystem.AppPortal.Finance
{
    public partial class DriverPay : BasePage<DriverPay>
    {
        [Dependency]
        public IFinanceDriverDal _finance_driver { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.DriverPay;
                }
            }
        }
        protected void gridFinanceDeliver_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            if (!grid.IsNewRowEditing)
            {
                object id = grid.GetRowValues(grid.EditingRowVisibleIndex, grid.KeyFieldName);
                UpdateControll<T_Finance_Driver>.SetValueToControl(grid);
                //SpecialLogisticsSystem.UserControl.ASPxTextBox aggregate_amount =
                //    grid.FindEditFormTemplateControl(T_Finance_Driver.AggregateAmountColumnName) as SpecialLogisticsSystem.UserControl.ASPxTextBox;
                //SpecialLogisticsSystem.UserControl.ASPxTextBox settle_accounts =
                //    grid.FindEditFormTemplateControl(T_Finance_Driver.SettleAccountsColumnName) as SpecialLogisticsSystem.UserControl.ASPxTextBox;
                //settle_accounts.Text = aggregate_amount.Text;
                //EmployeeLookUp operator_man = grid.FindEditFormTemplateControl(T_Finance_Driver.OperatorColumnName) as EmployeeLookUp;
                //operator_man.IsSetDefault = true;
            }
        }

        protected void gridFinanceDeliver_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Finance_Driver finance_deliver = new T_Finance_Driver();
            finance_deliver.id = Guid.NewGuid();
            UIHelpers.TryUpdateModel<T_Finance_Driver>.ToUpdateModel(finance_deliver, gridFinanceDeliver);
            finance_deliver.stowage_id = ConvertHelper.ObjectToGuid(e.Keys[0]).Value;
            finance_deliver.branch_id = UserProvide.GetCurrentBranchID();
            _finance_driver.Insert(finance_deliver);
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridFinanceDeliver.CancelEdit();
        }

        protected void deliverDataSourceDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridFinanceDeliver.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridFinanceDeliver.FilterExpression) ? gridFinanceDeliver.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}