using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{
    public static class ConvertHelper
    {
        //public static System.Nullable<T> ToObject<From, To>(From from)
        //{
        //    To? to = null;

        //    return to; 
        //}

        public static string ToString(object obj)
        {
            string result = string.Empty;
            if (null != obj)
            {
                if (obj is DateTime && obj.Equals(DateTime.MinValue))
                {
                    result = string.Empty;
                }
                else
                {
                    result = obj.ToString();
                }
            }
            return result;
        }

        public static string RemoveHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        public static string ToString(DateTime? obj, string format)
        {
            string result = string.Empty;
            if (obj.HasValue)
            {
                result = obj.Value.ToString(format);
            }
            return result;
        }

        public static int ToInt(string s)
        {
            decimal d = 0;
            int i = 0;
            if (decimal.TryParse(s, out d))
            {
                i = (int)d;
            }
            else
            {
                i = int.TryParse(s, out i) ? i : 0;
            }
            return i;
        }

        public static int ToInt(object obj)
        {
            return ToInt(ToString(obj));
        }

        public static int? ToIntOrNull(string s)
        {
            int i = 0;
            if (string.IsNullOrEmpty(s) || !int.TryParse(s, out i))
            {
                return null;
            }
            else
            {
                return ToInt(s);
            }
        }

        public static bool ToBool(string obj)
        {
            bool result = bool.TryParse(obj, out result) ? result : false;
            return result;
        }

        public static bool ToBool(object obj)
        {
            return ToBool(ToString(obj));
        }

        public static decimal ToDecimal(object obj)
        {
            return ToDecimal(ToString(obj));
        }

        public static decimal ToDecimal(string s)
        {
            decimal d = decimal.TryParse(s, out d) ? d : 0;
            return d;
        }

        public static long ToLong(string s)
        {
            decimal d = 0;
            long l = 0;
            if (decimal.TryParse(s, out d))
            {
                l = (long)d;
            }
            else
            {
                l = long.TryParse(s, out l) ? l : 0;
            }

            return l;
        }

        public static long ToLong(object obj)
        {
            return ToLong(ToString(obj));
        }

        public static DateTime? ToDateTime(string dateTimeString)
        {
            DateTime dt = DateTime.TryParse(dateTimeString, out dt) ? dt : DateTime.MinValue;

            DateTime? result = null;

            if (!dt.Equals(DateTime.MinValue))
            {
                result = dt;
            }

            return result;
        }

        public static DateTime? ToDateTime(object dateTimeString)
        {
            return ToDateTime(ToString(dateTimeString));
        }

        public static DateTime ToDateTime(string dateTimeString, string format)
        {
            DateTime dt = DateTime.MinValue;
            try
            {
                dt = DateTime.ParseExact(dateTimeString, format, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch { }
            return dt;
        }

        public static DateTime? ToDateTimeOrNull(string dateTimeString, string format)
        {
            var sperator = format.ToUpper().Replace("Y", string.Empty).Replace("M", string.Empty)
                .Replace("D", string.Empty).Replace("H", string.Empty).Replace("S", string.Empty).ToCharArray();
            var date = dateTimeString.Split(sperator);
            if (date.Length != format.Split(sperator).Length)
            {
                return null;
            }

            for (int i = 0; i < date.Length && i < 3; i++)
            {
                if (date[i].Length == 1)
                {
                    date[i] = "0" + date[i];
                }
            }

            string newDate = string.Empty;

            for (int i = 0; i < date.Length; i++)
            {
                newDate += date[i];
                if (i < date.Length - 1)
                {
                    newDate += sperator[0];
                }
            }

            DateTime? result = null;
            DateTime dt = DateTime.MinValue;
            var isOK = DateTime.TryParseExact(newDate, format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            if (isOK)
            {
                result = dt;
            }
            return result;
        }

        public static DateTime? ToDateTimeOrNull(object dateTimeString, string format)
        {
            return ToDateTimeOrNull(ToString(dateTimeString), format);
        }

        public static string ToXml(string str)
        {
            if (null == str || str.Trim() == "")
                return "";

            str = str.Replace(@"&", @"&amp;");
            str = str.Replace(@"<", @"&lt;");
            str = str.Replace(@">", @"&gt;");
            str = str.Replace(@"""", @"&quot;");
            str = str.Replace(@"'", @"&apos;");
            return str;
        }

        /// <summary>
        /// only for string to enum
        /// </summary>
        /// <typeparam name="T">must be enum</typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static System.Nullable<T> ToEnum<T>(string str) where T : struct
        {
            T result = default(T);
            try
            {
                result = (T)Enum.Parse(typeof(T), str, true);
            }
            catch
            {
                return null;
            }

            return result;
        }

        public static string FilterHTML(string htmlstring)
        {
            //delete script
            htmlstring = Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //delete HTML
            htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            htmlstring.Replace("<", "");

            htmlstring.Replace(">", "");

            htmlstring.Replace("\r\n", "");

            htmlstring = HttpContext.Current.Server.HtmlEncode(htmlstring).Trim();

            return htmlstring;
        }
    }
}
