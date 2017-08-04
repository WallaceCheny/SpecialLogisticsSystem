namespace Ms.Data
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public interface IBaseStoredProcedureBuilder
    {
        int Execute();
        TValue ParameterValue<TValue>(string name);
        [return: Dynamic(new bool[] { false, true })]
        List<object> Query();
        List<TEntity> Query<TEntity>(Action<TEntity, IDataReader> customMapper = null);
        TList Query<TEntity, TList>(Action<TEntity, IDataReader> customMapper) where TList: IList<TEntity>;
        [return: Dynamic]
        object QueryAndFeild();
        void QueryComplex<TEntity>(IList<TEntity> list, Action<IList<TEntity>, IDataReader> customMapper);
        TEntity QueryComplexSingle<TEntity>(Func<IDataReader, TEntity> customMapper);
        [return: Dynamic]
        object QuerySingle();
        TEntity QuerySingle<TEntity>(Action<TEntity, IDataReader> customMapper = null);
    }
}

