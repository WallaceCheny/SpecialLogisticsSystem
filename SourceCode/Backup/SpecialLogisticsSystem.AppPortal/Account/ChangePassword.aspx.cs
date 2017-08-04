using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Tool;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.Account
{
    public partial class ChangePassword : BasePage<ChangePassword>
    {
        [Dependency]
        public ICmUserDal _user { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form.Count > 0)
            {
                string oldPassword = DEncrypt.Encrypt(Request["oldPassword"]);
                string newPassword = DEncrypt.Encrypt(Request["newPassword"]);
                var user = _user.GetSingle(UIHelpers.UserProvide.GetCurrentUserId());
                Response.Clear();
                if (user.password != oldPassword)
                    Response.Write("{\"success\":false,\"msg\":\"原密码不正确\"}");
                else
                {
                    user.password = newPassword;
                    _user.Update(user);
                    Response.Write("{\"success\":true,\"msg\":\"密码修改成功\"}");
                }
                Response.ContentType = "application/json";
                Response.Flush();
                Response.End();
            }
        }
    }
}
