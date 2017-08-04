namespace Ms.Data
{
    using mscorlib;
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class x7927126fe5cc7aa8
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>> _x78aa12e3f9c521fc = new ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>>();

        public static bool x007dd346f7c545cd(Type x43163d22e8cd5a71)
        {
            // This item is obfuscated and can not be translated.
            bool flag;
            if (x43163d22e8cd5a71.IsEnum)
            {
                goto Label_0038;
            }
            while ((((uint) flag) & 0) == 0)
            {
                bool flag2;
                if (!x43163d22e8cd5a71.IsPrimitive || ((((uint) flag) + ((uint) flag2)) > uint.MaxValue))
                {
                    break;
                }
            Label_0038:
                if (false)
                {
                    return false;
                }
                return true;
            Label_0041:
                if (!x43163d22e8cd5a71.IsValueType && (x43163d22e8cd5a71 != typeof(string)))
                {
                }
                goto Label_0038;
            }
            goto Label_0041;
        }

        public static bool x218bb7401cb15bc9<T>()
        {
            // This item is obfuscated and can not be translated.
            bool flag;
            bool flag2;
            Type type = typeof(T);
            if (((((uint) flag) - ((uint) flag2)) >= 0) && (((((uint) flag) + ((uint) flag)) <= uint.MaxValue) && !type.IsClass))
            {
            }
            flag2 = true;
            if (((((uint) flag2) | 0x7fffffff) != 0) && flag2)
            {
                return false;
            }
            return true;
        }

        public static bool x2e7a2ea5da15ce85(object xccb63ca5f63dc470)
        {
            bool flag2 = !(xccb63ca5f63dc470 is ICollection);
            while (!flag2)
            {
                bool flag = true;
                if ((((uint) flag) & 0) == 0)
                {
                }
                return flag;
            }
            return false;
        }

        public static object x426d90076ff5477f(object xccb63ca5f63dc470, PropertyInfo x46710263f0fedd95)
        {
            return x46710263f0fedd95.GetValue(xccb63ca5f63dc470, null);
        }

        public static object x426d90076ff5477f(object xccb63ca5f63dc470, string xc3513c7f2bbafa84)
        {
            string str;
            int num;
            bool flag;
            string[] strArray = xc3513c7f2bbafa84.Split(new char[] { '.' });
            goto Label_00CF;
        Label_0036:
            if (num < strArray.Length)
            {
                str = strArray[num];
                goto Label_009D;
            }
        Label_0096:
            if (0x7fffffff != 0)
            {
                return xccb63ca5f63dc470;
            }
        Label_009D:
            if (xccb63ca5f63dc470 == null)
            {
                return null;
                if (((uint) flag) < 0)
                {
                    goto Label_00CF;
                }
            }
            PropertyInfo property = xccb63ca5f63dc470.GetType().GetProperty(str);
            if (0 == 0)
            {
                flag = property != null;
                if (!flag)
                {
                    if (((uint) flag) >= 0)
                    {
                    }
                    if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                    {
                        return null;
                    }
                }
                else
                {
                    xccb63ca5f63dc470 = x426d90076ff5477f(xccb63ca5f63dc470, property);
                }
                num++;
                goto Label_0036;
            }
            goto Label_0096;
        Label_00CF:
            num = 0;
            goto Label_0036;
        }

        public static object x54b3b5e4f95ed9f6(Type x43163d22e8cd5a71)
        {
            bool flag = !x43163d22e8cd5a71.IsValueType;
            while (-1 != 0)
            {
                if (!flag)
                {
                    break;
                }
                return null;
            }
            return Activator.CreateInstance(x43163d22e8cd5a71);
        }

        public static object x5d2ca24278753411(object xccb63ca5f63dc470, string xc15bd84e01929885)
        {
            IDictionary<string, object> dictionary = (IDictionary<string, object>) xccb63ca5f63dc470;
            return dictionary[xc15bd84e01929885];
        }

        private static Dictionary<string, PropertyInfo> x7521cb80e9c50c79(Type x43163d22e8cd5a71)
        {
            PropertyInfo[] infoArray2;
            int num;
            bool flag;
            Dictionary<string, PropertyInfo> dictionary = new Dictionary<string, PropertyInfo>();
            PropertyInfo[] properties = x43163d22e8cd5a71.GetProperties();
            if ((((uint) flag) + ((uint) num)) >= 0)
            {
                infoArray2 = properties;
                num = 0;
                if (4 == 0)
                {
                    goto Label_001B;
                }
            }
            else
            {
                Dictionary<string, PropertyInfo> dictionary2;
                return dictionary2;
            }
        Label_0011:
            flag = num < infoArray2.Length;
        Label_001B:
            if (!flag)
            {
                return dictionary;
            }
            PropertyInfo info = infoArray2[num];
            dictionary.Add(info.Name.ToLower(), info);
            num++;
            goto Label_0011;
        }

        public static string x8953c81157029c40<T>(Expression<Func<T, object>> xbf5efe8743edba7b)
        {
            string str = null;
            UnaryExpression expression;
            string str2;
            bool flag = !(xbf5efe8743edba7b.Body is UnaryExpression);
            goto Label_0073;
        Label_0028:
            if (3 != 0)
            {
                goto Label_0032;
            }
        Label_002F:
            if (!flag)
            {
                str = xbf5efe8743edba7b.Body.ToString();
                goto Label_0028;
            }
        Label_0032:
            str = str.Replace(xbf5efe8743edba7b.Parameters[0] + ".", string.Empty);
        Label_0054:
            str2 = str;
            if (2 == 0)
            {
                goto Label_0078;
            }
            if (0 != 0)
            {
                goto Label_0028;
            }
            return str2;
        Label_005D:
            flag = str != null;
            if (3 == 0)
            {
                goto Label_0054;
            }
            goto Label_002F;
        Label_0073:
            if (flag)
            {
                if (0 != 0)
                {
                    return str2;
                }
                goto Label_005D;
            }
        Label_0078:
            expression = (UnaryExpression) xbf5efe8743edba7b.Body;
            flag = expression.NodeType != ExpressionType.Convert;
            if (!flag)
            {
                str = expression.Operand.ToString();
            }
            if (((((uint) flag) & 0) == 0) && (0 == 0))
            {
                goto Label_005D;
            }
            goto Label_0073;
        }

        public static Type x9e21889ac45fb290(PropertyInfo x46710263f0fedd95)
        {
            bool flag = !xefcc03d48af71949(x46710263f0fedd95);
            if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
            {
            }
            if (!flag)
            {
                return x46710263f0fedd95.PropertyType.GetGenericArguments()[0];
            }
            return x46710263f0fedd95.PropertyType;
        }

        public static List<string> xe488d2903917d1a5<T>(Expression<Func<T, object>>[] x78f0278ac6863c90)
        {
            List<string> list2;
            Expression<Func<T, object>>[] expressionArray;
            int num;
            bool flag;
            List<string> list = new List<string>();
            if (0 == 0)
            {
                expressionArray = x78f0278ac6863c90;
                num = 0;
                goto Label_003E;
            }
        Label_000D:
            if (((uint) num) < 0)
            {
                goto Label_005E;
            }
            return list2;
        Label_003E:
            flag = num < expressionArray.Length;
            if (!flag)
            {
                list2 = list;
                if (((((uint) num) + ((uint) flag)) <= uint.MaxValue) && ((((uint) flag) | uint.MaxValue) == 0))
                {
                    goto Label_005E;
                }
                goto Label_000D;
            }
            Expression<Func<T, object>> expression = expressionArray[num];
            string item = x8953c81157029c40<T>(expression);
        Label_005E:
            list.Add(item);
            num++;
            goto Label_003E;
        }

        public static bool xefcc03d48af71949(PropertyInfo x46710263f0fedd95)
        {
            bool flag;
            bool flag2;
            System.Boolean ReflectorVariable0;
            if (!x46710263f0fedd95.PropertyType.IsGenericType)
            {
                ReflectorVariable0 = false;
                goto Label_0051;
            }
            if (8 != 0)
            {
                ReflectorVariable0 = true;
                goto Label_0051;
            }
        Label_0015:
            flag = false;
            if ((((uint) flag2) + ((uint) flag2)) <= uint.MaxValue)
            {
            }
            return flag;
        Label_0051:
            if (ReflectorVariable0 ? !(x46710263f0fedd95.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) : true)
            {
                goto Label_0015;
            }
            return true;
        }

        public static Dictionary<string, PropertyInfo> xfc2d0dcac70a78ed(Type x43163d22e8cd5a71)
        {
            return _x78aa12e3f9c521fc.GetOrAdd(x43163d22e8cd5a71, new Func<Type, Dictionary<string, PropertyInfo>>(x7927126fe5cc7aa8.x7521cb80e9c50c79));
        }
    }
}

