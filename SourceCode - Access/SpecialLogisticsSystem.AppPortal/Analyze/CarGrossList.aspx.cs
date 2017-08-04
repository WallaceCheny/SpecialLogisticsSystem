using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.Analyze
{
    public partial class CarGrossList : BasePage<CarGrossList>
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

        protected void grossDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridStowageProfile.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridStowageProfile.FilterExpression) ? gridStowageProfile.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}