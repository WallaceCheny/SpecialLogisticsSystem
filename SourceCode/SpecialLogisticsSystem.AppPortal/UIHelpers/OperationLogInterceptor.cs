using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class OperationLogInterceptor : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            object[] customAttributes = input.MethodBase.GetCustomAttributes(typeof(CustomAttribute), false);
            string name = string.Empty; bool begin = false, after = false;
            if ((customAttributes == null) || (customAttributes.Length == 0))
                name = input.MethodBase.DeclaringType.Name;
            else
            {
                CustomAttribute attribute = (CustomAttribute)customAttributes[0];
                name = attribute.Description;
                begin = attribute.Begin;
                after = attribute.After;
            }
            string className = input.MethodBase.DeclaringType.Name;
            string methodName = input.MethodBase.Name;
            //string generic = input.MethodBase.DeclaringType.IsGenericType ? string.Format("<{0}>", input.MethodBase.DeclaringType.GetGenericArguments().Select(p => p.Name).Aggregate((i, j) => { return i + "," + j; })) : string.Empty;
            string generic = input.MethodBase.DeclaringType.IsGenericType ? string.Format("<{0}>", input.MethodBase.DeclaringType.GetGenericArguments().ToStringList()) : string.Empty;
            string arguments = input.Arguments.ToStringList();
            //执行前Logging
            if (begin)
                LogHelper.WriteLog(new
                {
                    name = name,
                    type = "执行前",
                    method = string.Format("{0}{1}.{2}({3})", className, generic, methodName, arguments),
                    parameters = new List<object>(),
                    result = string.Empty,
                    result_date = DateTime.Now
                }.ToJsonTime());
            //Invoke method
            IMethodReturn msg = getNext()(input, getNext);
            if (after && msg.Exception == null)
            {
                List<object> vals = new List<object>();
                int i = 0;
                foreach (object param in input.Arguments)
                {
                    ParameterInfo parameterInfo = input.Arguments.GetParameterInfo(i);
                    vals.Add(new { name = parameterInfo.Name, type = parameterInfo.ParameterType, value = param });
                    i++;
                }
                //执行后Logging
                LogHelper.WriteLog(new
                {
                    name = name,
                    type = "执行后",
                    method = string.Format("{0}{1}.{2}({3})", className, generic, methodName, arguments),
                    parameters = vals,
                    result = msg.ReturnValue,
                    result_date = DateTime.Now
                }.ToJsonTime());
            }
            return msg;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
    public static class EnumerableExtensions
    {
        public static string ToStringList(this System.Collections.IEnumerable list)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("{0}, ", item);
            }
            if (sb.Length > 0) sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}