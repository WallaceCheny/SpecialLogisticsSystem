namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Linq.Expressions;

    internal class x6447be342da7459f
    {
        private readonly BuilderData _x4a3f0a05c02f235f;

        internal x6447be342da7459f(BuilderData data)
        {
            this._x4a3f0a05c02f235f = data;
        }

        private void x031986ef006ac686(string x59ee5b80c99ccc1a, object xbcea506a33cf9111, Type x43163d22e8cd5a71, DataTypes x5fa349731ac3ba80, int x0ceec69a97f73617)
        {
            string parameterName = x59ee5b80c99ccc1a;
            this._x4a3f0a05c02f235f.Columns.Add(new TableColumn(x59ee5b80c99ccc1a, xbcea506a33cf9111, parameterName));
            if (x5fa349731ac3ba80 == DataTypes.Object)
            {
                if (0 == 0)
                {
                }
                x5fa349731ac3ba80 = this._x4a3f0a05c02f235f.Command.Data.Context.Data.Provider.GetDbTypeForClrType(x43163d22e8cd5a71);
            }
            this.xa1cdeb732aed99de(parameterName, xbcea506a33cf9111, x5fa349731ac3ba80, ParameterDirection.Input, false, x0ceec69a97f73617);
        }

        internal void x06d5957f527cfaa8<T>(params Expression<Func<T, object>>[] xafa728469f885f99)
        {
            HashSet<string> set;
            Expression<Func<T, object>> expression;
            string str;
            bool flag;
            Expression<Func<T, object>>[] expressionArray;
            int num;
            Dictionary<string, PropertyInfo> dictionary = x7927126fe5cc7aa8.xfc2d0dcac70a78ed(this._x4a3f0a05c02f235f.Item.GetType());
            goto Label_01F1;
        Label_0031:
            using (Dictionary<string, PropertyInfo>.Enumerator enumerator = dictionary.GetEnumerator())
            {
                Type type;
                object obj2;
                Func<string, bool> func;
                <>c__DisplayClass2<T> class2;
                goto Label_0082;
            Label_003C:
                obj2 = x7927126fe5cc7aa8.x426d90076ff5477f(this._x4a3f0a05c02f235f.Item, class2.property.Value);
                KeyValuePair<string, PropertyInfo> property = class2.property;
                this.x031986ef006ac686(property.Value.Name, obj2, type, DataTypes.Object, 0);
            Label_0082:
                flag = enumerator.MoveNext();
                if (flag)
                {
                    goto Label_014D;
                }
                if ((((uint) num) & 0) == 0)
                {
                    if ((((uint) num) | 0x7fffffff) != 0)
                    {
                        return;
                    }
                    goto Label_014D;
                }
            Label_00C6:
                type = x7927126fe5cc7aa8.x9e21889ac45fb290(property.Value);
                if (0 == 0)
                {
                    goto Label_003C;
                }
            Label_00D7:
                if (func == null)
                {
                    func = new Func<string, bool>(class2.<AutoMapColumnsAction>b__0);
                }
                flag = set.SingleOrDefault<string>(func) == null;
                if (!flag)
                {
                    if (8 == 0)
                    {
                        goto Label_011B;
                    }
                    goto Label_0082;
                }
                property = class2.property;
                goto Label_00C6;
            Label_011B:
                class2 = new <>c__DisplayClass2<T>();
                class2.property = enumerator.Current;
                if ((((uint) flag) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_00D7;
                }
                goto Label_003C;
            Label_014D:
                func = null;
                goto Label_011B;
            }
            return;
        Label_0177:
            if (!flag)
            {
                expressionArray = xafa728469f885f99;
                num = 0;
            }
            else
            {
                goto Label_0031;
            }
        Label_0194:
            flag = num < expressionArray.Length;
            if (flag)
            {
                expression = expressionArray[num];
            }
            else
            {
                if (((uint) flag) >= 0)
                {
                    goto Label_0031;
                }
                goto Label_0177;
            }
        Label_01A5:
            str = new PropertyExpressionParser<T>(this._x4a3f0a05c02f235f.Item, expression).Name;
            if ((((uint) num) + ((uint) flag)) <= uint.MaxValue)
            {
                if (0 != 0)
                {
                    goto Label_01A5;
                }
                set.Add(str);
                num++;
                goto Label_0194;
            }
        Label_01F1:
            set = new HashSet<string>();
            if ((((uint) flag) - ((uint) num)) < 0)
            {
                goto Label_01F1;
            }
            flag = xafa728469f885f99 == null;
            goto Label_0177;
        }

        internal void x102778f7a6dca84c(params string[] xafa728469f885f99)
        {
            HashSet<string> set;
            bool flag;
            string[] strArray;
            int num;
            IEnumerator<KeyValuePair<string, object>> enumerator;
            IDictionary<string, object> item = (IDictionary<string, object>) this._x4a3f0a05c02f235f.Item;
            goto Label_01AF;
        Label_003C:
            enumerator = item.GetEnumerator();
            try
            {
                string str2;
                Func<string, bool> func;
                goto Label_00A1;
            Label_0047:
                if (flag)
                {
                    goto Label_00BB;
                }
                return;
            Label_0050:
                if (!flag)
                {
                    this.x031986ef006ac686(property.Key, property.Value, typeof(object), DataTypes.Object, 0);
                }
                while ((((uint) num) | 15) == 0)
                {
                }
            Label_00A1:
                flag = enumerator.MoveNext();
                goto Label_0047;
            Label_00AE:
                flag = str2 != null;
                goto Label_0050;
            Label_00BB:
                func = null;
                KeyValuePair<string, object> property = enumerator.Current;
                if (func == null)
                {
                    <>c__DisplayClass6 class2;
                    func = new Func<string, bool>(class2.<AutoMapDynamicTypeColumnsAction>b__4);
                }
                str2 = set.SingleOrDefault<string>(func);
                if (0 != 0)
                {
                    goto Label_00A1;
                }
                if (0 == 0)
                {
                    goto Label_00AE;
                }
                return;
            }
            finally
            {
                flag = enumerator == null;
                while (!flag)
                {
                    enumerator.Dispose();
                    break;
                }
            }
            if ((((uint) flag) - ((uint) num)) >= 0)
            {
                return;
            }
            goto Label_01AF;
        Label_0120:
            if (((((uint) num) + ((uint) flag)) >= 0) && ((((uint) num) + ((uint) num)) >= 0))
            {
                if (0xff == 0)
                {
                    goto Label_0120;
                }
                goto Label_003C;
            }
        Label_013B:
            if (!flag)
            {
                strArray = xafa728469f885f99;
            }
            else if (0 == 0)
            {
                goto Label_003C;
            }
            num = 0;
        Label_0163:
            flag = num < strArray.Length;
            if (flag)
            {
                string str = strArray[num];
                set.Add(str);
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_013B;
                }
                num++;
                goto Label_0163;
            }
            goto Label_0120;
        Label_01AF:
            if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0120;
            }
            set = new HashSet<string>();
            flag = xafa728469f885f99 == null;
            goto Label_013B;
        }

        internal void x37e59daf82eb99a9(string xc15bd84e01929885, DataTypes x2a8ddb579d4d448d, int x0ceec69a97f73617)
        {
            this.xa1cdeb732aed99de(xc15bd84e01929885, null, x2a8ddb579d4d448d, ParameterDirection.Output, false, x0ceec69a97f73617);
        }

        internal void x4fe829ca2eecf51e<T>(Expression<Func<T, object>> xbf5efe8743edba7b, DataTypes x5fa349731ac3ba80, int x0ceec69a97f73617)
        {
            PropertyExpressionParser<T> parser = new PropertyExpressionParser<T>(this._x4a3f0a05c02f235f.Item, xbf5efe8743edba7b);
            this.x031986ef006ac686(parser.Name, parser.Value, parser.Type, x5fa349731ac3ba80, x0ceec69a97f73617);
        }

        internal void x4fe829ca2eecf51e(string x59ee5b80c99ccc1a, object xbcea506a33cf9111, DataTypes x5fa349731ac3ba80, int x0ceec69a97f73617)
        {
            this.x031986ef006ac686(x59ee5b80c99ccc1a, xbcea506a33cf9111, typeof(object), x5fa349731ac3ba80, x0ceec69a97f73617);
        }

        internal void x7f921c9ab27d105d<T>(Expression<Func<T, object>> xbf5efe8743edba7b, DataTypes x5fa349731ac3ba80, int x0ceec69a97f73617)
        {
            PropertyExpressionParser<T> parser = new PropertyExpressionParser<T>(this._x4a3f0a05c02f235f.Item, xbf5efe8743edba7b);
            this.x7f921c9ab27d105d(parser.Name, parser.Value, x5fa349731ac3ba80, x0ceec69a97f73617);
        }

        internal void x7f921c9ab27d105d(string x59ee5b80c99ccc1a, object xbcea506a33cf9111, DataTypes x5fa349731ac3ba80, int x0ceec69a97f73617)
        {
            string str = x59ee5b80c99ccc1a;
            this.xa1cdeb732aed99de(str, xbcea506a33cf9111, x5fa349731ac3ba80, ParameterDirection.Input, true, 0);
            this._x4a3f0a05c02f235f.Where.Add(new TableColumn(x59ee5b80c99ccc1a, xbcea506a33cf9111, str));
        }

        private void xa1cdeb732aed99de(string xc15bd84e01929885, object xbcea506a33cf9111, DataTypes xd2f3d36b96df4542, ParameterDirection x23e85093ba3a7d1d, bool xe0bf1a2cfed4236d, int x0ceec69a97f73617)
        {
            this._x4a3f0a05c02f235f.Command.Parameter(xc15bd84e01929885, xbcea506a33cf9111, xd2f3d36b96df4542, x23e85093ba3a7d1d, x0ceec69a97f73617);
        }

        internal void xbb4ee78ca371cf6a(ExpandoObject xccb63ca5f63dc470, string xc3513c7f2bbafa84, DataTypes x5fa349731ac3ba80, int x0ceec69a97f73617)
        {
            object obj2 = xccb63ca5f63dc470[xc3513c7f2bbafa84];
            this.x031986ef006ac686(xc3513c7f2bbafa84, obj2, typeof(object), x5fa349731ac3ba80, x0ceec69a97f73617);
        }
    }
}

