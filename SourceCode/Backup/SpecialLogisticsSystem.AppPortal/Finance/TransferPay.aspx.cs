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
using DevExpress.Web.ASPxEditors;

namespace SpecialLogisticsSystem.AppPortal.Finance
{
    public partial class TransferPay : BasePage<TransferPay>
    {
        [Dependency]
        public ITransferMainDal _transfer { get; set; }
        [Dependency]
        public IFinanceServiceDal _finance_service { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.TransferPay;
                }
            }
        }

        protected void gridFinanceService_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> ids = gridFinanceService.GetSelectedFieldValues(gridFinanceService.KeyFieldName);
            switch (e.Parameters)
            {
                default:
                    break;
            }
            gridFinanceService.DataBind();
        }

        protected void gridFinanceService_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            if (!grid.IsNewRowEditing)
            {
                object id = grid.GetRowValues(grid.EditingRowVisibleIndex, grid.KeyFieldName);
                UpdateControll<T_Finance_Service>.SetValueToControl(grid);
                ASPxTextBox transfer_bill = grid.FindEditFormTemplateControl("transfer_bill") as ASPxTextBox;
                ASPxTextBox settlement_payment = grid.FindEditFormTemplateControl("settlement_payment") as ASPxTextBox;
                settlement_payment.Text = transfer_bill.Text;
            }
        }

        protected void gridFinanceService_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Finance_Service finance_service = new T_Finance_Service();
            finance_service.id = Guid.NewGuid();
            UIHelpers.TryUpdateModel<T_Finance_Service>.ToUpdateModel(finance_service, gridFinanceService);
            finance_service.transfer_id = ConvertHelper.ObjectToGuid(e.Keys[0]).Value;
            finance_service.branch_id = UserProvide.GetCurrentBranchID();
            _finance_service.Insert(finance_service);
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridFinanceService.CancelEdit();
        }

        protected void wayDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridFinanceService.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridFinanceService.FilterExpression) ? gridFinanceService.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}