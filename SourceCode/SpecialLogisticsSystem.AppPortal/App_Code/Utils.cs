using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpecialLogisticsSystem.AppPortal
{
    public static class Utils
    {
        const string
            CurrentDemoKey = "DXCurrentDemo",
            CurrentThemeCookieKeyPrefix = "DXCurrentTheme",
            DefaultTheme = "DevEx";

        public static string CurrentThemeCookieKey
        {
            get { return CurrentThemeCookieKeyPrefix; }
        }

        public static string CurrentTheme
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[CurrentThemeCookieKey] != null)
                    return HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[CurrentThemeCookieKey].Value);
                return DefaultTheme;
            }
        }
    }
}