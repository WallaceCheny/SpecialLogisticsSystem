
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;
using System;

namespace SpecialLogisticsSystem.Tool
{
    public class CookieHelper
    {
        public static void ClearTicketCookie(string ticketName, string domain)
        {
            SaveTicketCookie(ticketName, string.Empty, -1, domain);
        }

        public static void SaveTicketCookie(string ticketName, string userData, int expiresMinutes, string domain)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            0,
            ticketName,
            DateTime.Now,
            DateTime.Now.AddYears(1),
            false,
            userData);
            string cookieStr = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(ticketName, cookieStr);
            cookie.HttpOnly = true;
            if (expiresMinutes != 0)
                cookie.Expires = DateTime.Now.AddMinutes(expiresMinutes);
            if ((HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("localhost") < 0) && !string.IsNullOrEmpty(domain))
                cookie.Domain = domain;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string GetTicketFromCookie(string ticketName)
        {
            if (HttpContext.Current != null && HttpContext.Current.Request.Cookies[ticketName] != null && !string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[ticketName].Value))
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[ticketName].Value);
                return ticket.UserData;
            }

            return string.Empty;
        }

        public static string GetTicketData(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(data);
                return ticket.UserData;
            }

            return string.Empty;
        }

        public static void SaveCookie(string key, string value, string domain)
        {
            HttpCookie cookie = new HttpCookie(key, value);
            cookie.HttpOnly = true;
            if ((HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("localhost") < 0) && !string.IsNullOrEmpty(domain))
                cookie.Domain = domain;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string GetCookie(string cookieKey)
        {
            if (HttpContext.Current.Request.Cookies[cookieKey] != null && !string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[cookieKey].Value))
            {
                return HttpContext.Current.Request.Cookies[cookieKey].Value;
            }

            return string.Empty;
        }
    }
}
