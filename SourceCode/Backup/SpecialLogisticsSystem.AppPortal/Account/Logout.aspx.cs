using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //删除登录用户记录
            T_Cm_User user = UIHelpers.UserProvide.GetCurrentUser();
            //if (user != null)
            //{
            //    BLL.T_Cm_User_Cache.provide.Delete(Guid.Parse(user.cache_id));
            //}
            CookieHelper.ClearTicketCookie(UIHelpers.Constants.LOGIN_COOKIE_NAME, string.Empty);
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}