namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;

    public interface IUpdateBuilder<T>
    {
        IUpdateBuilder<T> AutoMap(params Expression<Func<T, object>>[] ignoreProperties);
        IUpdateBuilder<T> Column(Expression<Func<T, object>> expression, DataTypes parameterType = 13, int size = 0);
        IUpdateBuilder<T> Column(string columnName, object value, DataTypes parameterType = 13, int size = 0);
        int Execute();
        IUpdateBuilder<T> Where(Expression<Func<T, object>> expression, DataTypes parameterType = 13, int size = 0);
        IUpdateBuilder<T> Where(string columnName, object value, DataTypes parameterType = 13, int size = 0);
    }
}

