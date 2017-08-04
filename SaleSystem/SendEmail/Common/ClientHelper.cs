using System;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace Common
{
    public class ClientHelper
    {
        public static string GetRealIP()
        {
            string ip = string.Empty;
            try
            {
                HttpRequest request = HttpContext.Current.Request;

                if (request.ServerVariables["HTTP_VIA"] != null)
                {
                    ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                }
                else
                {
                    ip = request.UserHostAddress;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ip;
        }

        #region client js



        public static void AddCookie(HttpResponse response, string key, string value, int expireDays)
        {
            HttpCookie cookie = new HttpCookie(key, value);
            cookie.Expires = DateTime.Now.AddDays(expireDays);
            if (null != response.Cookies[key])
            {
                response.Cookies.Set(cookie);
            }
            else
            {
                response.Cookies.Add(cookie);
            }
        }

        public static void GetCookie(HttpRequest request, string key, out string value)
        {
            value = string.Empty;
            HttpCookie cookie = request.Cookies[key];
            if (null != cookie)
            {
                value = cookie.Value;
            }
        }

        public static bool IsCookie(HttpRequest request, string key)
        {
            HttpCookie cookie = request.Cookies[key];
            if (null != cookie)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// seem not working
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        public static void ClearCookie(HttpRequest request, string key)
        {
            if (null != request.Cookies[key])
            {
                request.Cookies.Remove(key);
            }
        }

        public static void ClearCookie(HttpRequest request, HttpResponse response, string key)
        {
            if (null != request.Cookies[key])
            {
                HttpCookie cookie = new HttpCookie(key);
                cookie.Expires = DateTime.Now.AddDays(-1d);
                response.Cookies.Add(cookie);
            }
        }

        public static void AddSession(HttpSessionState session, string key, object value)
        {
            session[key] = value;
        }

        public static void AddSession<T>(HttpSessionState session, string key, T value)
        {
            session[key] = value;
        }

        public static bool Download(HttpResponse response, string fileName, string showName)
        {
            bool result = false;

            try
            {
                FileInfo toDownload = new FileInfo(fileName);

                if (toDownload.Exists)
                {
                    const long chunkSize = 10000;
                    byte[] buffer = new byte[chunkSize];

                    response.Clear();
                    FileStream iStream = File.OpenRead(fileName);
                    long dataLengthToRead = iStream.Length;
                    if (showName.Length <= 0)
                    {
                        showName = toDownload.Name;
                    }
                    response.ContentType = "application/octet-stream";
                    response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(showName));
                    while (dataLengthToRead > 0 && response.IsClientConnected)
                    {
                        int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(chunkSize));
                        response.OutputStream.Write(buffer, 0, lengthRead);
                        response.Flush();
                        dataLengthToRead = dataLengthToRead - lengthRead;
                    }
                    iStream.Close();
                    response.Close();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static bool Download(HttpResponse response, string fileName)
        {
            return Download(response, fileName, string.Empty);
        }

        public static void ClearClientPageCache()
        {
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.AddHeader("pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("cache-control", "private");
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.Cache.SetNoStore();
        }

        public static void WriteErrorJs(Control updatePanel, string js)
        {
            js = string.Format("Dinner.App.ShowError('{0}')", js);
            if (!js.EndsWith(";"))
            {
                js = js + ";";
            }

            ScriptManager.RegisterStartupScript(updatePanel, updatePanel.GetType(), Guid.NewGuid().ToString(), js, true);
        }
        public static void WriteJs(Page thisPage, string js)
        {
            if (!js.EndsWith(";"))
            {
                js = js + ";";
            }

            thisPage.ClientScript.RegisterStartupScript(thisPage.GetType(), Guid.NewGuid().ToString(), js, true);
        }
        public static void WriteSuccessJs(Control updatePanel, string js)
        {
            js = string.Format("Dinner.App.ShowMessage('{0}')", js);
            if (!js.EndsWith(";"))
            {
                js = js + ";";
            }

            ScriptManager.RegisterStartupScript(updatePanel, updatePanel.GetType(), Guid.NewGuid().ToString(), js, true);
        }
        #endregion
    }
}
