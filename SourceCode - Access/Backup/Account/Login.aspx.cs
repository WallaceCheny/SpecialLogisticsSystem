using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Account
{
    public partial class Login : BasePage<Login>
    {
        [Dependency]
        public ICmUserDal _user { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string UserLoginName = this.LoginUser.UserName;//得到输入的用户名
            string UserLoginPwd = DEncrypt.Encrypt(this.LoginUser.Password);//得到输入的密码
            QueryInfo<T_Cm_User> queryInfo = new QueryInfo<T_Cm_User>();
            queryInfo.SetQuery("user_name", UserLoginName);
            queryInfo.SetQuery("password", UserLoginPwd);
            queryInfo.SetQuery("status", (int)UserState.Enable);
            IList<T_Cm_User> userList = _user.GetList(queryInfo);
            //验证通过
            if (userList.Count > 0)
            {
                ////删除到时未退出的登录用户记录
                //BLL.T_Cm_User_Cache.provide.Delete("dateadd(n,30,last_date) <= getdate()");

                ////登录用户数
                //string ln = ConfigurationManager.AppSettings["logNumber"];
                ////解密登录用户数
                //int num =ConvertHelper.ObjectToInt32(DEncrypt.Decrypt(ln));
                //验证登录数
                //int logincount = BLL.T_Cm_User_Cache.provide.GetCount("dateadd(n,30,last_date) > getdate()");
                //if (num != 10963588 && logincount >= num)
                //{
                //    //已达到登录用户数不能登录
                //    e.Authenticated = false;
                //}
                //else
                //{
                ////写入登录用户表
                //Model.T_Cm_User_Cache usercache = new Model.T_Cm_User_Cache();
                //usercache.id = Guid.NewGuid();
                //usercache.user_id = user.id;
                //usercache.last_date = DateTime.Now;
                //BLL.T_Cm_User_Cache.provide.Add(usercache);
                //user.cache_id = usercache.id.ToString();

                int expiresMinutes = UIHelpers.Constants.USER_COOKIE_SAVETIME;
                T_Cm_User user = userList.FirstOrDefault();
                string userData = JsonHelper.ToJson<T_Cm_User>(user);
                CookieHelper.SaveTicketCookie(UIHelpers.Constants.LOGIN_COOKIE_NAME, userData, expiresMinutes, string.Empty);
                //这里需要增加用户相关权限（角色和数据）获取的代码，
                e.Authenticated = true;
                //}
            }
            else
            {
                e.Authenticated = false;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }
    }
}
