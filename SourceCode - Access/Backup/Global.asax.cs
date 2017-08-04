using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using SpecialLogisticsSystem.Tool;
using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal
{
    public class Global : System.Web.HttpApplication, IContainerAccessor
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            // Assign Application_Error as a callback error handler for DevExpress web controls 
            ASPxWebControl.CallbackError += new EventHandler(Application_Error); 
            LogHelper.SetConfig();
            _container = Bootstrapper.BuildUnityContainer();
            CodeName.Instance.Initialize(new CodeHelper());
           
        }


        void Application_BeginRequest(object sender, EventArgs e)
        {
            ////theme
            //string themeName = UIHelpers.Constants.DEFAULT_THEME_NAME;
            //if (!string.IsNullOrEmpty(Request[UIHelpers.Constants.THEME_COOKIE_NAME]))
            //{
            //    themeName = Request[UIHelpers.Constants.THEME_COOKIE_NAME];
            //}
            //HttpContext.Current.Items[UIHelpers.Constants.THEME_COOKIE_NAME] = themeName;
        }


        void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            DevExpress.Web.ASPxClasses.ASPxWebControl.GlobalTheme = Utils.CurrentTheme;

            //if (HttpContext.Current.Handler is Page)
            //{
            //    var currentPage = (Page)HttpContext.Current.Handler;
            //    currentPage.Theme = Convert.ToString(HttpContext.Current.Items[UIHelpers.Constants.THEME_COOKIE_NAME]);
            //}
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            // 在出现未处理的错误时运行的代码
            //if (null != Server.GetLastError())
            //{
            //    Exception exp = Server.GetLastError().GetBaseException();
            //    if (exp.GetType().Name.Equals("HttpException"))
            //    {
            //        HttpException httpEx = (HttpException)exp;
            //        int httpCode = httpEx.GetHttpCode();
            //        if (httpCode == 404)
            //        {
            //            return;
            //        }
            //    }
            //    Server.ClearError();
            //    ExceptionHelper.WriteLog(exp);
            //    System.Web.HttpContext.Current.Server.Transfer("/Error.aspx");
            //}
            
            Exception objExp = HttpContext.Current.Server.GetLastError();
            //"<br/><strong>客户机IP</strong>：" + Request.UserHostAddress + "<br /><strong>错误地址</strong>：" + Request.Url
            LogHelper.WriteLog(string.Empty, objExp);
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        private static IUnityContainer _container;
        public IUnityContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }
    }
    public static class Bootstrapper
    {
        public static IUnityContainer BuildUnityContainer()
        {
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = HttpContext.Current.Server.MapPath("~/unity.config") };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            var container = new UnityContainer();
            container.LoadConfiguration(section);
            //IUnityContainer container = new UnityContainer();
            //unitySection.Configure(container);
            return container;
        }
    }
}
