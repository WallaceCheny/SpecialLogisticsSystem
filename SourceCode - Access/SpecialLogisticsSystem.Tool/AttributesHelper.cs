using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Tool
{
    public static class AttributesHelper
    {
        public static string GetDisplayNameAttributes(Type modelType)
        {
            string displayName = string.Empty;
            DisplayNameAttribute name = modelType.GetCustomAttributes(typeof(DisplayNameAttribute), false)[0] as DisplayNameAttribute;
            if (null != name)
            {
                displayName = name.DisplayName;
            }
            return displayName;
        }
    }
}
