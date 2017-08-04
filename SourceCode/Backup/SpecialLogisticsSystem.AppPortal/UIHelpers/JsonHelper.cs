using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// 将时间由"\/Date(10000000000-0700)\/" 格式转换成 "yyyy-MM-dd HH:mm:ss" 格式的字符串
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static string GetDatetimeString(Match m)
        {
            string sRet = "";
            try
            {
                System.DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
                dt = dt.ToLocalTime();
                sRet = dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            { }
            return sRet;
        }
        /// <summary>
        /// 将时间由 "yyyy-MM-dd HH:mm:ss" 格式的字符串转换成"\/Date(10000000000-0700)\/" 格式
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static string GetDatetimeJson(Match m)
        {
            String sRet = "";
            try
            {
                DateTime dt = DateTime.Parse(m.Groups[1].Value);
                dt = dt.ToUniversalTime();
                TimeSpan ts = dt - DateTime.Parse("1970-01-01");
                sRet = string.Format("\\/Date({0}-0700)\\/", ts.TotalMilliseconds);
            }
            catch
            { }
            return sRet;
        }
        /// <summary>
        /// 扩展Object 方法 ToJson
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String ToJson(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            String sRet = serializer.Serialize(obj);
            //将时间由"\/Date(10000000000-0700)\/" 格式转换成 "yyyy-MM-dd HH:mm:ss" 格式的字符串
            //string sPattern = @"\\/Date\((\d+)-\d+\)\\/";
            string sPattern = @"\\/Date\((\d+)\)\\/";
            MatchEvaluator myMatchEvaluator = new MatchEvaluator(GetDatetimeString);
            Regex reg = new Regex(sPattern);
            sRet = reg.Replace(sRet, myMatchEvaluator);
            return sRet;
        }
        public static T FromJson<T>(String sJasonData)
        {
            JsonSerializerSettings jsonSs = new JsonSerializerSettings();
            jsonSs.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            jsonSs.Converters.Add(new Newtonsoft.Json.Converters.DataTableConverter());
            return JsonConvert.DeserializeObject<T>(sJasonData, jsonSs);
        }
        public static String ToJson<T>(this T obj)
        {
            JsonSerializerSettings jsonSs = new JsonSerializerSettings();
            jsonSs.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            jsonSs.Converters.Add(new Newtonsoft.Json.Converters.DataTableConverter());
            string json = JsonConvert.SerializeObject(obj, Formatting.None, jsonSs);
            return json;
        }
        public static String ToJsonTime<T>(this T obj)
        {
            JsonSerializerSettings jsonSs = new JsonSerializerSettings();
            var timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
            jsonSs.Converters.Add(timeConverter);
            jsonSs.Converters.Add(new Newtonsoft.Json.Converters.DataTableConverter());
            string json = JsonConvert.SerializeObject(obj, Formatting.None, jsonSs);
            return json;
        }
    }
}
