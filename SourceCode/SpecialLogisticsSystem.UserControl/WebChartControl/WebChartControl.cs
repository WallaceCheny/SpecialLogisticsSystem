using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.UserControl
{
    public class WebChartControl : DevExpress.XtraCharts.Web.WebChartControl
    {
        protected override void OnInit(EventArgs e)
        {
            this.ClientInstanceName = this.ID;
            base.OnInit(e);
        }
    }
}
