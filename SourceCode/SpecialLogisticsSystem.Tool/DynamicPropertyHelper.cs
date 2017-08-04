using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Web.UI;

namespace SpecialLogisticsSystem.Tool
{
    public static class DynamicPropertyHelper
    {
        private const char ExpressionPartsSeperator = '.';
        private static readonly IList<string> IgnoreAuditedFields = new List<string>();

        static DynamicPropertyHelper()
        {
        }

        public static bool AllColumnAttributePropertyAreDefault<T>(T entity) where T : class
        {
            if (entity == null) throw new ArgumentNullException("entity");

            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                if (IgnoreAuditedFields.Contains(propertyInfo.Name)) continue;
                object[] attributes = propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (attributes.Length == 0) continue;
                if ((attributes[0] as ColumnAttribute).IsDbGenerated) continue;

                object propertyValue = propertyInfo.GetGetMethod().Invoke(entity, null);
                object defaultValue = GetDefaultValue(propertyInfo.PropertyType);

                if (propertyInfo.PropertyType.IsValueType)
                {
                    if (defaultValue == null && propertyValue == null) continue;

                    if (defaultValue != null)
                    {
                        if (!defaultValue.Equals(propertyValue)) return false;
                    }

                    if (propertyValue != null)
                    {
                        if (!propertyValue.Equals(defaultValue)) return false;
                    }
                }
                else
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        if (string.IsNullOrEmpty((string)propertyValue) && string.IsNullOrEmpty((string)defaultValue))
                        {
                            //do nothing
                        }
                        else
                        {
                            if (propertyValue != defaultValue) return false;
                        }
                    }
                    else
                    {
                        if (propertyValue != defaultValue) return false;
                    }
                }
            }

            return true;
        }

        private static object GetDefaultValue(Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }

        public static Func<T, TValue> CreateGetter<T, TValue>(PropertyInfo propertyInfo)
        {
            if (typeof(T) != propertyInfo.DeclaringType) throw new ArgumentException();

            var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
            var property = Expression.Property(instance, propertyInfo);
            return (Func<T, TValue>)Expression.Lambda(property, instance).Compile();
        }

        public static Action<T, TValue> CreateSetter<T, TValue>(PropertyInfo propertyInfo)
        {
            if (typeof(T) != propertyInfo.DeclaringType) throw new ArgumentException();

            var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
            var argument = Expression.Parameter(typeof(TValue), "a");
            var setterCall = Expression.Call(instance, propertyInfo.GetSetMethod());
            return (Action<T, TValue>)Expression.Lambda(setterCall, instance, argument).Compile();
        }

        public static Action<T, TValue> CreateSetter<T, TValue>(Expression<Func<T, TValue>> getter)
        {
            ParameterExpression parameter;
            Expression instance;
            MemberExpression propertyOrField;

            GetMemberExpression(getter, out parameter, out instance, out propertyOrField);

            // Very simple case: p => p.Property or p => p.Field
            if (parameter == instance)
            {
                if (propertyOrField.Member.MemberType == MemberTypes.Property)
                {
                    // This is FASTER than Expression trees! (5x on my benchmarks) but works only on properties
                    PropertyInfo property = propertyOrField.Member as PropertyInfo;
                    MethodInfo setter = property.GetSetMethod();
                    var action = (Action<T, TValue>)Delegate.CreateDelegate(typeof(Action<T, TValue>), setter);
                    return action;
                }
                #region .NET 3.5
                else // if (propertyOrField.Member.MemberType == MemberTypes.Field)
                {
                    // 1.2x slower than 4.0 method, 5x faster than 3.5 method
                    FieldInfo field = propertyOrField.Member as FieldInfo;
                    var action = CreateSetter<T, TValue>(field);
                    return action;
                }
                #endregion
            }

            ParameterExpression value = Expression.Parameter(typeof(TValue), "val");

            Expression expr = null;

            #region .NET 3.5
            if (propertyOrField.Member.MemberType == MemberTypes.Property)
            {
                PropertyInfo property = propertyOrField.Member as PropertyInfo;
                MethodInfo setter = property.GetSetMethod();
                expr = Expression.Call(instance, setter, value);
            }
            else // if (propertyOrField.Member.MemberType == MemberTypes.Field)
            {
                expr = FieldSetter(propertyOrField, value);
            }
            #endregion

            //#region .NET 4.0
            //// For field access it's 5x faster than the 3.5 method and 1.2x than "simple" method. For property access nearly same speed (1.1x faster).
            //expr = Expression.Assign(propertyOrField, value);
            //#endregion

            return Expression.Lambda<Action<T, TValue>>(expr, parameter, value).Compile();
        }

        private static void GetMemberExpression<T, U>(Expression<Func<T, U>> expression, out ParameterExpression parameter, out Expression instance, out MemberExpression propertyOrField)
        {
            Expression current = expression.Body;

            while (current.NodeType == ExpressionType.Convert || current.NodeType == ExpressionType.TypeAs)
            {
                current = (current as UnaryExpression).Operand;
            }

            if (current.NodeType != ExpressionType.MemberAccess)
            {
                throw new ArgumentException();
            }

            propertyOrField = current as MemberExpression;
            current = propertyOrField.Expression;

            instance = current;

            while (current.NodeType != ExpressionType.Parameter)
            {
                if (current.NodeType == ExpressionType.Convert || current.NodeType == ExpressionType.TypeAs)
                {
                    current = (current as UnaryExpression).Operand;
                }
                else if (current.NodeType == ExpressionType.MemberAccess)
                {
                    current = (current as MemberExpression).Expression;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            parameter = current as ParameterExpression;
        }

        #region .NET 3.5

        // Based on http://stackoverflow.com/questions/321650/how-do-i-set-a-field-value-in-an-c-expression-tree/321686#321686
        private static Action<T, TValue> CreateSetter<T, TValue>(FieldInfo field)
        {
            DynamicMethod m = new DynamicMethod("setter", typeof(void), new Type[] { typeof(T), typeof(TValue) }, typeof(DynamicPropertyHelper));
            ILGenerator cg = m.GetILGenerator();

            // arg0.<field> = arg1
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Stfld, field);
            cg.Emit(OpCodes.Ret);

            return (Action<T, TValue>)m.CreateDelegate(typeof(Action<T, TValue>));
        }

        // Based on http://stackoverflow.com/questions/208969/assignment-in-net-3-5-expression-trees/3972359#3972359
        private static Expression FieldSetter(Expression left, Expression right)
        {
            return
                Expression.Call(
                    null,
                    typeof(DynamicPropertyHelper)
                        .GetMethod("AssignTo", BindingFlags.NonPublic | BindingFlags.Static)
                        .MakeGenericMethod(left.Type),
                    left,
                    right);
        }

        //This method can not be deleted
        private static void AssignTo<T>(ref T left, T right)  // note the 'ref', which is
        {                                                     // important when assigning
            left = right;                                     // to value types!
        }

        #endregion

        #region <<SetPropertyValue>>

        /// <summary>
        /// only one part supported
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lambdaExpression"></param>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue<T>(Expression<Func<T, bool>> lambdaExpression, T instance, bool value)
        {
            var memberSelectorExpression = lambdaExpression.Body as MemberExpression;
            var property = memberSelectorExpression.Member as PropertyInfo;
            property.SetValue(instance, value, null);
        }

        #endregion

        #region <<GetPropertyValue>>

        //Note: may be low performance because of calling DataBinder.Eval
        public static object GetPropertyValue<T>(Expression<Func<T, object>> lambdaExpression, T instance)
        {
            string[] expressionParts = GetExpressionParts(lambdaExpression);
            //Can avoid NullReferenceException
            return DataBinder.Eval(instance, string.Join(".", expressionParts));
        }

        #endregion

        public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            MemberExpression memberExpression;
            if (expression.Body.NodeType != ExpressionType.MemberAccess)
            {
                if (expression.Body is UnaryExpression)
                {
                    var unaryExpression = (UnaryExpression)expression.Body;
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                    return memberExpression.Member.Name;
                }
                else
                {
                    throw new ArgumentException("expression");
                }
            }
            else
            {
                memberExpression = (MemberExpression)expression.Body;
            }

            return memberExpression.Member.Name;
        }

        public static Type GetPropertyTypeName<T>(Expression<Func<T, object>> expression)
        {
            if ((expression.Body.NodeType == ExpressionType.Convert) ||
                (expression.Body.NodeType == ExpressionType.ConvertChecked))
            {
                var unary = expression.Body as UnaryExpression;
                if (unary != null)
                    return unary.Operand.Type;
            }

            return expression.Body.Type;
        }

        private static string[] GetExpressionParts<T>(Expression<Func<T, object>> lambdaExpression)
        {
            string[] expressionParts = null;

            if (lambdaExpression.Body.NodeType == ExpressionType.MemberAccess)
            {
                expressionParts = lambdaExpression.Body.ToString().Split(ExpressionPartsSeperator).Skip(1).ToArray();
            }
            else if (lambdaExpression.Body.NodeType == ExpressionType.Convert)
            {
                expressionParts = (lambdaExpression.Body as UnaryExpression).Operand.ToString().Split(ExpressionPartsSeperator).Skip(1).ToArray();
            }
            return expressionParts;
        }
    }
}
