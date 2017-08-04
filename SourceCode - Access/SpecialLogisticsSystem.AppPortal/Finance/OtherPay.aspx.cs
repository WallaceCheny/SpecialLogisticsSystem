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

namespace SpecialLogisticsSystem.AppPortal.Finance
{
    public partial class OtherPay : BasePage<OtherPay>
    {
        [Dependency]
        public IFinanceDailyDal _daily_finance { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridFinanceDaily_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            T_Finance_Daily dailyFinance = new T_Finance_Daily();
            UIHelpers.TryUpdateModel<T_Finance_Daily>.ToUpdateModel(dailyFinance, gridFinanceDaily);
            dailyFinance.id = Guid.NewGuid();
            dailyFinance.branch_id = UserProvide.GetCurrentBranchID();
            _daily_finance.Insert(dailyFinance);
            RefreshGrid(e);
        }

        protected void gridFinanceDaily_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Finance_Daily dailyFinance = _daily_finance.GetSingle(e.Keys[0]);
            UIHelpers.TryUpdateModel<T_Finance_Daily>.ToUpdateModel(dailyFinance, gridFinanceDaily);
            _daily_finance.Update(dailyFinance);
            RefreshGrid(e);
        }

        private void RefreshGrid(CancelEventArgs e)
        {
            gridFinanceDaily.DataBind();
            e.Cancel = true;
            gridFinanceDaily.CancelEdit();
        }

        protected void gridFinanceDaily_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> ids = gridFinanceDaily.GetSelectedFieldValues(gridFinanceDaily.KeyFieldName);
            _daily_finance.Delete(ids);
            RefreshGrid(e);
            gridFinanceDaily.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }

        protected void gridFinanceDaily_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
            UpdateControll<T_Finance_Daily>.SetValueToControl(grid);
        }

        protected void dailyDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridFinanceDaily.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridFinanceDaily.FilterExpression) ? gridFinanceDaily.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}