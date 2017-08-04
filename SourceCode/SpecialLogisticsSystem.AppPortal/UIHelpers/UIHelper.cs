using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Microsoft.Practices;
using Microsoft.Practices.Unity;

namespace SpecialLogisticsSystem.AppPortal
{
    public class UIHelper
    {
        /// <summary>
        /// 判断是否是Nullable类型数据
        /// </summary>
        /// <param name="theType"></param>
        /// <returns></returns>
        public static bool IsNullableType(Type theType)
        {
            return (theType.IsGenericType && theType.
              GetGenericTypeDefinition().Equals
              (typeof(Nullable<>)));
        }

        public static T Resolve<T>()
        {
            var accessor = HttpContext.Current.ApplicationInstance as SpecialLogisticsSystem.AppPortal.IContainerAccessor;
            var container = accessor.Container;
            return container.Resolve<T>();
        }
    }
}