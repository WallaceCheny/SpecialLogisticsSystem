using System.IO;
using System.Reflection;
using DevExpress.XtraReports.UI;
using System.Globalization;
using System.Web;

namespace SpecialLogisticsSystem.AppPortal
{
    public static class Helper
    {
        public static string GetReportPath(XtraReport report, string ext)
        {
            string reportName = report.Name;
            if (string.IsNullOrEmpty(reportName))
                reportName = report.GetType().Name;
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(directoryName, string.Format("{0}.{1}", reportName, ext));
        }
        public static string GetRelativePath(string name)
        {
            return HttpContext.Current.Request.MapPath("~/App_Data/" + name);
        }
        public static string GetRelativeStyleSheetPath(string styleSheetPath)
        {
            return GetRelativePath(styleSheetPath.Substring(styleSheetPath.LastIndexOf('\\') + 1));
        }
        static bool IsIE55_6
        {
            get
            {
                HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
                return string.Compare(browser.Browser, "ie", true, CultureInfo.InvariantCulture) == 0
                    && (browser.Version == "5.5" || browser.Version == "6.0");
            }
        }
        public static string GetPageBorderCSSLink()
        {
            return string.Format(@"<link rel=""stylesheet"" type=""text/css"" href=""{0}/Content/PageBorders/styles{1}.css"" />",
                HttpContext.Current.Request.ApplicationPath, IsIE55_6 ? "_ie6" : string.Empty);
        }
    }
}
