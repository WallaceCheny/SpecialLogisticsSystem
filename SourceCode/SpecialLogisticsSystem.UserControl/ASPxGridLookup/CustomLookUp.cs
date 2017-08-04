using System;
using DevExpress.Web.ASPxGridLookup;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxGridLookup : DevExpress.Web.ASPxGridLookup.ASPxGridLookup
    {
        protected override void OnInit(EventArgs e)
        {
            this.ClientInstanceName = this.ClientID;
            CommandFunction._look_Command(this, e);
            base.OnInit(e);
        }
    }
}
