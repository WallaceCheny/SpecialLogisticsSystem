using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.SessionState;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    /// <summary>
    /// Summary description for AjaxHelper
    /// </summary>
    public class AjaxHelper : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request["method"]))
                return;
            Type type = typeof(Ajax);// Type.GetType("SpecialLogisticsSystem.AppPortal.UIHelpers.Ajax");
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            object classObject = constructor.Invoke(new object[] { });
            string method = context.Request["method"];
            MethodInfo methodInfo = type.GetMethod(method, BindingFlags.SetProperty | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            ParameterInfo[] paramsInfo = methodInfo.GetParameters();
            List<object> lstObj = new List<object>();
            foreach (var param in paramsInfo)
            {
                Type tType = param.ParameterType;
                if (IsNullableType(tType))
                {
                    if (string.IsNullOrEmpty(context.Request[param.Name]))
                        lstObj.Add(null);
                    else
                    {
                        var t = Nullable.GetUnderlyingType(tType);
                        lstObj.Add(Convert.ChangeType(context.Request[param.Name], t));
                    }
                }
                else if (tType.Equals(typeof(string)) || (!tType.IsInterface && !tType.IsClass && !tType.IsGenericType))
                    lstObj.Add(Convert.ChangeType(context.Request[param.Name], tType));
                else if (tType.IsClass)
                    lstObj.Add(Newtonsoft.Json.JsonConvert.DeserializeObject(context.Request[param.Name], tType));
            }
            object returnValue = methodInfo.Invoke(classObject, lstObj.ToArray());
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            //context.Response.ContentType = "text/html";
            if (methodInfo.GetCustomAttributes(typeof(JsonViewAttribute), true).Length == 1)
                context.Response.Write(returnValue);
            else
                context.Response.Write(returnValue.ToJson());
        }
        /// <summary>
        /// 判断是否是Nullable类型数据
        /// </summary>
        /// <param name="theType"></param>
        /// <returns></returns>
        private bool IsNullableType(Type theType)
        {
            return (theType.IsGenericType && theType.
              GetGenericTypeDefinition().Equals
              (typeof(Nullable<>)));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}