namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;

    public interface IInsertUpdateBuilder<T>
    {
        IInsertUpdateBuilder<T> Column(Expression<Func<T, object>> expression, DataTypes parameterType = 13, int size = 0);
        IInsertUpdateBuilder<T> Column(string columnName, object value, DataTypes parameterType = 13, int size = 0);
    }
}

