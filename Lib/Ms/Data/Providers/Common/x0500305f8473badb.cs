namespace Ms.Data.Providers.Common
{
    using Ms.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Xml.Linq;

    internal class x0500305f8473badb
    {
        private static readonly object _x26cfbfcc55032b93 = new object();
        private static Dictionary<Type, DataTypes> _x8f76a1a9d286e18b;

        public DataTypes x0da8b7b7e680146f(Type xec7f3ce379ddca28)
        {
            bool flag;
            DataTypes types2;
            bool flag2 = _x8f76a1a9d286e18b != null;
            if ((((uint) flag) - ((uint) flag2)) >= 0)
            {
                if (((((uint) flag) + ((uint) flag2)) > uint.MaxValue) || !flag2)
                {
                    object obj2;
                    flag = false;
                    try
                    {
                        Monitor.Enter(obj2 = _x26cfbfcc55032b93, ref flag);
                        goto Label_01FB;
                    Label_00A7:
                        _x8f76a1a9d286e18b.Add(typeof(DBNull), DataTypes.String);
                        _x8f76a1a9d286e18b.Add(typeof(float), DataTypes.Single);
                        _x8f76a1a9d286e18b.Add(typeof(double), DataTypes.Double);
                        if (0 != 0)
                        {
                            goto Label_0194;
                        }
                        goto Label_0142;
                    Label_00F5:
                        _x8f76a1a9d286e18b.Add(typeof(bool), DataTypes.Boolean);
                        if ((((uint) flag2) - ((uint) flag)) > uint.MaxValue)
                        {
                            goto Label_01FB;
                        }
                        _x8f76a1a9d286e18b.Add(typeof(char), DataTypes.String);
                        goto Label_00A7;
                    Label_0142:
                        if (0xff != 0)
                        {
                            goto Label_0270;
                        }
                        goto Label_01FB;
                    Label_0151:
                        _x8f76a1a9d286e18b.Add(typeof(DateTime), DataTypes.DateTime);
                        _x8f76a1a9d286e18b.Add(typeof(XDocument), DataTypes.Xml);
                        _x8f76a1a9d286e18b.Add(typeof(decimal), DataTypes.Decimal);
                    Label_0194:
                        _x8f76a1a9d286e18b.Add(typeof(Guid), DataTypes.Guid);
                        goto Label_01F8;
                    Label_01AD:
                        if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                        {
                            goto Label_022D;
                        }
                        _x8f76a1a9d286e18b.Add(typeof(long), DataTypes.Int64);
                        _x8f76a1a9d286e18b.Add(typeof(string), DataTypes.String);
                        goto Label_0151;
                    Label_01F8:
                        if (0 == 0)
                        {
                            goto Label_00F5;
                        }
                    Label_01FB:
                        flag2 = _x8f76a1a9d286e18b != null;
                        if (flag2)
                        {
                            goto Label_0270;
                        }
                        _x8f76a1a9d286e18b = new Dictionary<Type, DataTypes>();
                        _x8f76a1a9d286e18b.Add(typeof(short), DataTypes.Int16);
                    Label_022D:
                        _x8f76a1a9d286e18b.Add(typeof(int), DataTypes.Int32);
                        goto Label_01AD;
                    }
                    finally
                    {
                        flag2 = !flag;
                        while (!flag2)
                        {
                            Monitor.Exit(obj2);
                            break;
                        }
                    }
                }
                goto Label_0270;
            }
        Label_006E:
            if (flag2)
            {
                return _x8f76a1a9d286e18b[xec7f3ce379ddca28];
            }
            if (((uint) flag2) >= 0)
            {
                do
                {
                    types2 = DataTypes.Object;
                }
                while ((((uint) flag) + ((uint) flag)) < 0);
            }
            return types2;
        Label_0270:
            flag2 = _x8f76a1a9d286e18b.ContainsKey(xec7f3ce379ddca28);
            goto Label_006E;
        }
    }
}

