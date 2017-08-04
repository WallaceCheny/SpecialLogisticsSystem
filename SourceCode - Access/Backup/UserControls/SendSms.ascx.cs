using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.AppPortal.UIHelpers;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class SendSms : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void reback_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            SmsHelper.SendSms(txtReceiver.Text, txtSmsContext.Text);
        }
    }
}