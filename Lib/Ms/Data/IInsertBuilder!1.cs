namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;

    public interface IInsertBuilder<T>
    {
        IInsertBuilder<T> AutoMap(params Expression<Func<T, object>>[] ignoreProperties);
        IInsertBuilder<T> Column(Expression<Func<T, object>> expression, DataTypes parameterType = 13, int size = 0);
        IInsertBuilder<T> Column(string columnName, object value, DataTypes parameterType = 13, int size = 0);
        int Execute();
        TReturn ExecuteReturnLastId<TReturn>(string identityColumnName = null);
    }
}

