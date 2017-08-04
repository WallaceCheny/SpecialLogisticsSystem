using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class LabelWayStatue : BaseUserControl
    {
        public void SetValue(string statue)
        {
            if (string.IsNullOrEmpty(statue)) statue = WayStatue.New.ToString();
            lblStatue.Text = ConvertHelper.GetEnumAttribute(statue, typeof(WayStatue));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}