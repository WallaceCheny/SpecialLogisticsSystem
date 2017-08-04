using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.Analyze
{
    public partial class FinanceList : BasePage<FinanceList>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.Code;
                }
            }
        }

        protected void financeDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["filter"] = !string.IsNullOrEmpty(gridFinance.FilterExpression) ? gridFinance.FilterExpression : string.Empty;
        }
    }
}