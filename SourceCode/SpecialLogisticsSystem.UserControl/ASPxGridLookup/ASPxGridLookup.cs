using System;
using DevExpress.Web.ASPxGridLookup;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxGridLookup : DevExpress.Web.ASPxGridLookup.ASPxGridLookup
    {
        protected override void OnInit(EventArgs e)
        {
            this.ClientInstanceName = this.ClientID;
            CommandFunction._look_Command(this, e);
            //分页格式
            PagerFunction._look_Pager(this, e);
            this.GridViewProperties.SettingsText.EmptyDataRow = ConstantsHelper.Empty_Data;
            base.OnInit(e);
        }
    }
}
