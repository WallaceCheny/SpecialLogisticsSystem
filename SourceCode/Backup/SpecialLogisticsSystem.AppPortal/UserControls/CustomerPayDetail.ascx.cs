using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class CustomerPayDetail : BaseUserControl
    {
        public CustomerSettleType SettleType
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}