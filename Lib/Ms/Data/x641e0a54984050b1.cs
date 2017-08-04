namespace Ms.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class x641e0a54984050b1
    {
        internal static List<x4a37bdfb56acb0d7> x0bf67ddd05b3bcb8(IDataReader xe134235b3526fa75)
        {
            int num;
            bool flag;
            List<x4a37bdfb56acb0d7> source = new List<x4a37bdfb56acb0d7>();
        Label_0066:
            num = 0;
        Label_001E:
            flag = num < xe134235b3526fa75.FieldCount;
            if (0 == 0)
            {
                <>c__DisplayClass1 class2;
                List<x4a37bdfb56acb0d7> list2;
                if ((((uint) flag) | 4) == 0)
                {
                    return list2;
                }
                if (!flag)
                {
                    list2 = source;
                    if (3 != 0)
                    {
                    }
                    return list2;
                }
                x4a37bdfb56acb0d7 column = new x4a37bdfb56acb0d7(num, xe134235b3526fa75.GetName(num), xe134235b3526fa75.GetFieldType(num));
                flag = source.SingleOrDefault<x4a37bdfb56acb0d7>(new Func<x4a37bdfb56acb0d7, bool>(class2.<GetDataReaderFields>b__0)) != null;
                if (!flag)
                {
                    source.Add(column);
                }
                do
                {
                    num++;
                }
                while ((((uint) num) - ((uint) flag)) < 0);
                goto Label_001E;
            }
            goto Label_0066;
        }

        internal static object x1fd66af94fec6cea(IDataReader xe134235b3526fa75, int xc0c4c459c6ccbd00, bool x22385e12a96098ab)
        {
            object obj2 = xe134235b3526fa75[xc0c4c459c6ccbd00];
            Type type = obj2.GetType();
            bool flag = obj2 != DBNull.Value;
        Label_0016:
            if (!flag)
            {
                flag = !x22385e12a96098ab;
                if (!flag && ((((uint) flag) + ((uint) xc0c4c459c6ccbd00)) >= 0))
                {
                    return null;
                }
                flag = !(type == typeof(DateTime));
                if (((((uint) flag) - ((uint) x22385e12a96098ab)) <= uint.MaxValue) && flag)
                {
                    if ((((uint) xc0c4c459c6ccbd00) | 3) == 0)
                    {
                        object obj3;
                        return obj3;
                    }
                    if (0 == 0)
                    {
                        return obj2;
                    }
                    goto Label_0016;
                }
            }
            else
            {
                return obj2;
            }
            return DateTime.MinValue;
        }
    }
}

