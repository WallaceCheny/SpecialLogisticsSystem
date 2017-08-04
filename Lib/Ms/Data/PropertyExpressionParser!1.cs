namespace Ms.Data
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public class PropertyExpressionParser<T>
    {
        private PropertyInfo _x46710263f0fedd95;
        private readonly object _xccb63ca5f63dc470;

        public PropertyExpressionParser(object item, Expression<Func<T, object>> propertyExpression)
        {
            this._xccb63ca5f63dc470 = item;
            this._x46710263f0fedd95 = PropertyExpressionParser<T>.x4ff37084a5d7d57f(propertyExpression);
        }

        private static PropertyInfo x4ff37084a5d7d57f(Expression<Func<T, object>> xd0072e8aa8c1411e)
        {
            bool flag = xd0072e8aa8c1411e.Body.NodeType != ExpressionType.Convert;
            if (!flag)
            {
                goto Label_00B1;
            }
            PropertyInfo member = ((MemberExpression) xd0072e8aa8c1411e.Body).Member as PropertyInfo;
        Label_0087:
            flag = member == null;
            if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
            {
                if ((((uint) flag) | 3) != 0)
                {
                    if (flag)
                    {
                        throw new ArgumentException(string.Format("Expression '{0}' does not refer to a property.", xd0072e8aa8c1411e.ToString()));
                    }
                    return typeof(T).GetProperty(member.Name);
                }
                goto Label_0087;
            }
            if (2 == 0)
            {
                PropertyInfo info2;
                return info2;
            }
        Label_00B1:
            member = ((MemberExpression) ((UnaryExpression) xd0072e8aa8c1411e.Body).Operand).Member as PropertyInfo;
            goto Label_0087;
        }

        public string Name
        {
            get
            {
                return this._x46710263f0fedd95.Name;
            }
        }

        public System.Type Type
        {
            get
            {
                return x7927126fe5cc7aa8.x9e21889ac45fb290(this._x46710263f0fedd95);
            }
        }

        public object Value
        {
            get
            {
                return x7927126fe5cc7aa8.x426d90076ff5477f(this._xccb63ca5f63dc470, this._x46710263f0fedd95);
            }
        }
    }
}

