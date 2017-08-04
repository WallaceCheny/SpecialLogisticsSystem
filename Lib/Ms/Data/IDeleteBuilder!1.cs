namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;

    public interface IDeleteBuilder<T>
    {
        int Execute();
        IDeleteBuilder<T> Where(Expression<Func<T, object>> expression, DataTypes parameterType = 13, int size = 0);
        IDeleteBuilder<T> Where(string columnName, object value, DataTypes parameterType = 13, int size = 0);
    }
}

