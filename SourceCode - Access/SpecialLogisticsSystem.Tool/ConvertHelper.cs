using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Tool
{
    public class ConvertHelper
    {
        public static string ReturnDefault(string expression, string defaultvalue)
        {
            return string.IsNullOrEmpty(expression) ? defaultvalue : expression;
        }

        public static bool ObjectToBoolean(object expression)
        {
            return ObjectToBool(expression);
        }
        public static bool ObjectToBool(object expression)
        {
            return ((expression != null) && ObjectToBool(expression, false));
        }

        public static bool ObjectToBool(object expression, bool defValue)
        {
            if (expression != null)
            {
                return StringToBool(expression.ToString(), defValue);
            }
            return defValue;
        }

        public static bool IsInt(object expression)
        {
            int rv = 0;
            if (expression == null) return false;
            return int.TryParse(expression.ToString(), out rv);
        }

        public static DateTime? ObjectToDateTime(object obj)
        {
            if (obj == null) return null;
            return StringToDateTime(obj.ToString());
        }

        public static DateTime ObjectToDateTime(object obj, DateTime defValue)
        {
            return StringToDateTime(obj.ToString(), defValue);
        }

        public static float ObjectToFloat(object strValue)
        {
            return ObjectToFloat(strValue.ToString(), 0f);
        }

        public static float ObjectToFloat(object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StringToFloat(strValue.ToString(), defValue);
        }

        public static double ObjectToDouble(object strValue)
        {
            return ObjectToDouble(strValue.ToString(), 0L);
        }

        public static double ObjectToDouble(object strValue, double defValue)
        {
            if (strValue == null || string.IsNullOrEmpty(strValue.ToString()))
            {
                return defValue;
            }
            return StringToDouble(strValue.ToString(), defValue);
        }

        public static int ObjectToInt32(object expression)
        {
            return ObjectToInt(expression, 0);
        }

        public static int ObjectToInt(object expression)
        {
            return ObjectToInt(expression, 0);
        }

        public static int ObjectToInt(object expression, int defValue)
        {
            if (expression != null)
            {
                return StringToInt(expression.ToString(), defValue);
            }
            return defValue;
        }

        public static long ObjectToInt64(object expression)
        {
            return ObjectToLong(expression, 0);
        }

        public static long ObjectToLong(object expression)
        {
            return ObjectToLong(expression, 0);
        }

        public static long ObjectToLong(object expression, int defValue)
        {
            if (expression != null)
            {
                return StringToLong(expression.ToString(), defValue);
            }
            return defValue;
        }


        public static string ObjectToString(object expression)
        {
            return expression != null ? expression.ToString() : string.Empty;
        }

        public static string ObjectToStandardDate(object expression)
        {
            if (expression == null) return string.Empty;
            DateTime? dateValue = ObjectToDateTime(expression);
            if (!dateValue.HasValue) return string.Empty;
            return dateValue.Value.ToString("yyyy-MM-dd");
        }

        public static Decimal ObjectToDecimal(object expression)
        {
            decimal d = 0;
            if (expression != null)
            {
                decimal.TryParse(expression.ToString(), out d);
            }
            return d;
        }

        public static Decimal StringToDecimal(string expression)
        {
            decimal d = 0;
            if (string.IsNullOrEmpty(expression) == false)
            {
                decimal.TryParse(expression, out d);
            }
            return d;
        }

        public static bool StringToBool(string expression, bool defValue)
        {
            if (expression != null)
            {
                if (string.Compare(expression, "true", true) == 0)
                {
                    return true;
                }
                if (string.Compare(expression, "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        public static bool StringToBool(string expression)
        {
            return StringToBool(expression, false);
        }

        public static bool StringToBoolean(string expression)
        {
            bool returnValue = false;
            bool.TryParse(expression, out returnValue);
            return returnValue;
        }

        public static DateTime StringToDateTime(string str)
        {
            return StringToDateTime(str, DateTime.Now);
        }

        public static DateTime StringToDateTime(string str, DateTime defValue)
        {
            DateTime dateTime;
            if (!string.IsNullOrEmpty(str) && DateTime.TryParse(str, out dateTime))
            {
                return dateTime;
            }
            return defValue;
        }

        public static float StringToFloat(object strValue)
        {
            if (strValue == null)
            {
                return 0f;
            }
            return StringToFloat(strValue.ToString(), 0f);
        }

        public static float StringToFloat(object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StringToFloat(strValue.ToString(), defValue);
        }

        public static float StringToFloat(string strValue, float defValue)
        {
            if ((strValue == null) || (strValue.Length > 10))
            {
                return defValue;
            }
            float intValue = defValue;
            if ((strValue != null) && Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                float.TryParse(strValue, out intValue);
            }
            return intValue;
        }

        public static double StringToDouble(string strValue, double defValue)
        {
            if ((strValue == null) || (strValue.Length > 10))
            {
                return defValue;
            }
            double intValue = defValue;
            if ((strValue != null) && Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                double.TryParse(strValue, out intValue);
            }
            return intValue;
        }


        public static int StringToInt(string str)
        {
            return StringToInt(str, 0);
        }

        public static long StringToLong(string str)
        {
            return StringToLong(str, 0);
        }

        public static int StringToInt(string str, int defValue)
        {
            int rv = defValue;
            int.TryParse(str, out rv);
            return rv;
        }


        public static long StringToLong(string str, int defValue)
        {
            long v = defValue;
            long.TryParse(str, out v);
            return v;
        }

        public static Guid? ObjectToGuid(object guid)
        {
            if (guid != null && guid != string.Empty)
            {
                return Guid.Parse(guid.ToString());
            }
            return null;
        }

        public static List<IDNameDescription> EnumnToNameDescription(Type type)
        {
            if (!type.IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            var values = Enum.GetValues(type);
            string[] names = Enum.GetNames(type);
            var liMembers = new List<IDNameDescription>();
            for (int i = 0; i <= values.Length - 1; i++)
            {
                var id = (int)values.GetValue(i);
                string category = GetEnumAttribute(values.GetValue(i).ToString(), type, typeof(CategoryAttribute));
                if (category == "Hidden") continue;
                string description = GetEnumAttribute(values.GetValue(i).ToString(), type, typeof(DescriptionAttribute));
                liMembers.Add(new IDNameDescription(id, names[i], description));
            }

            return liMembers;
        }

        public static string GetEnumAttribute(string item, Type enumType)
        {
            return GetEnumAttribute(item, enumType, typeof(DescriptionAttribute));
        }

        public static string GetEnumAttribute(string item, Type enumType, Type attribute)
        {
            FieldInfo fieldinfo = enumType.GetField(item);
            Object[] objDescription = fieldinfo.GetCustomAttributes(attribute, false);

            if (objDescription == null || objDescription.Length == 0)
            {
                return item.ToString();
            }
            else
            {
                if (attribute == typeof(DescriptionAttribute))
                {
                    return ((DescriptionAttribute)objDescription[0]).Description;
                }
                else
                {
                    return ((CategoryAttribute)objDescription[0]).Category;
                }
            }
        }
    }

    public class IDNameDescription
    {
        public IDNameDescription(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}