using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxCheckBox : DevExpress.Web.ASPxEditors.ASPxCheckBox
    {
        protected override void OnInit(EventArgs e)
        {
            this.ClientInstanceName = this.ID;
            base.OnInit(e);
        }
    }
}
