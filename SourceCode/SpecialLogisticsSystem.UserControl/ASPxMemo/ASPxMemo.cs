using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.UserControl
{
    public  class ASPxMemo : DevExpress.Web.ASPxEditors.ASPxMemo
    {
        protected override void OnInit(EventArgs e)
        {
            this.ClientInstanceName = this.ID;
            base.OnInit(e);
        }
    }
}
