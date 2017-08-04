using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace SendEmail.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtReceiver.Text=
                txtSubject.Text = "今天还好吗？";
                txtContent.Text = "物流行业在未来发展是不断完善的，竞争也很激烈，所以必须要有一款使用的软件来管理自己的公司，而且传统手工操作容易出错，一旦出错，客户的信任度就会大大降低。如果有需要物流管理系统，请联系www.ewlxt.com";
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            EmailHelper.SendMail(txtReceiver.Text, "", txtSubject.Text, txtContent.Text);
        }
    }
}
