/*
 public enum xxx
    {
        [DescriptionAttribute("xxxx")]
        x1,        
        x2,
        [DescriptionAttribute("xxxx")]
        x3,
        x4
    }
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Common
{
    public static class PropertyHelper
    {
        /// <summary>
        /// 获取枚举类子项描述信息
        /// </summary>
        /// <param name="enumSubitem">枚举类子项</param>        
        public static string GetEnumDescription(Enum enumSubitem)
        {
            string strValue = enumSubitem.ToString();

            FieldInfo fieldinfo = enumSubitem.GetType().GetField(strValue);
            Object[] objs = fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs == null || objs.Length == 0)
            {
            }
            else
            {
                DescriptionAttribute da = (DescriptionAttribute)objs[0];
                strValue = da.Description;
            }

            if (null == strValue || strValue.Length == 0)
            {
                strValue = enumSubitem.ToString();
            }

            return strValue;
        }
    }
}
