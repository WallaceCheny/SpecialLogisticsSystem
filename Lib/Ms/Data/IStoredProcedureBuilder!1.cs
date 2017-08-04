namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;

    public interface IStoredProcedureBuilder<T> : IBaseStoredProcedureBuilder, IDisposable
    {
        IStoredProcedureBuilder<T> AutoMap(params Expression<Func<T, object>>[] ignoreProperties);
        IStoredProcedureBuilder<T> Parameter(Expression<Func<T, object>> expression, DataTypes parameterType = 13, int size = 0);
        IStoredProcedureBuilder<T> Parameter(string name, object value, DataTypes parameterType = 13, int size = 0);
        IStoredProcedureBuilder<T> ParameterOut(string name, DataTypes parameterType, int size = 0);
    }
}

