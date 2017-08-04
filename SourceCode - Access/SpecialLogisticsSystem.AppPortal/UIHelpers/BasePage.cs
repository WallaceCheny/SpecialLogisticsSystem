using System;
using System.Web;
using System.Web.UI;
using Microsoft.Practices.Unity;
using System.Collections;
using SpecialLogisticsSystem.Tool;
using System.Globalization;
using System.Threading;

namespace SpecialLogisticsSystem.AppPortal
{
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }
    public abstract class BasePage<T>: Page where T:class
    {
        private IUnityContainer container;

        protected override void OnPreInit(EventArgs e)
        {
            InjectDependencies();
        }

        protected override void OnError(EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            // 在出现未处理的错误时运行的代码
            Exception objExp = HttpContext.Current.Server.GetLastError();
            LogHelper.WriteLog("<br/><strong>客户机IP</strong>：" + Request.UserHostAddress + "<br /><strong>错误地址</strong>：" + Request.Url, objExp);
        }

        protected virtual void InjectDependencies()
        {
            var context = HttpContext.Current;
            if (context == null)
            {
                return;
            }
            var accessor = context.ApplicationInstance as IContainerAccessor;
            if (accessor == null)
            {
                return;
            }
            container = accessor.Container;
            if (container == null)
            {
                throw new InvalidOperationException("No Unity container found");
            }
            container.BuildUp(this as T);
        }

        protected override void InitializeCulture()
        {
            CultureInfo culture = new CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            //base.InitializeCulture();
        }
    }
}