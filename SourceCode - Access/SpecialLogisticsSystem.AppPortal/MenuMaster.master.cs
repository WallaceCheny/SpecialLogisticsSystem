using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.AppPortal.UserControls;

namespace SpecialLogisticsSystem.AppPortal
{
    public partial class MenuMaster : System.Web.UI.MasterPage
    {
        public MainToolBar MenuToolBar
        {
            get {
               return this.viewMenu;
            }
        }
        public bool IsShowSearch
        {
            set
            {
                this.btnSearch.Visible = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}