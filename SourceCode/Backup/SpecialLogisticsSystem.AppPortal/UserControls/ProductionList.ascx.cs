using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class ProductionList : BaseUserControl
    {
        public void Refrsh()
        {
            gridWayTemp.DataBind();
        }

        public string Statue
        {
            set
            {
                hideStatue.Value = value;
            }
        }
        public string WayType
        {
            set
            {
                hideType.Value = value;
            }
        }
        public string ClosingJs
        {
            set
            {
                PopupProductList.ClientSideEvents.Closing = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void wayDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["filter"] = !string.IsNullOrEmpty(gridWayTemp.FilterExpression) ? gridWayTemp.FilterExpression : string.Empty;
        }
    }
}