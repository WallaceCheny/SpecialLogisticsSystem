using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxUploadControl : DevExpress.Web.ASPxUploadControl.ASPxUploadControl
    {
        protected override void OnInit(EventArgs e)
        {
            this.ShowProgressPanel = true;
            this.ShowClearFileSelectionButton = true;
            this.ShowAddRemoveButtons = false;
            this.ShowUploadButton = false;
            this.BrowseButton.Text = "浏览";
            base.OnInit(e);
        }
    }
}
