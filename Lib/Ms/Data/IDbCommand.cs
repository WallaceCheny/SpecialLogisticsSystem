namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public interface IDbCommand : IDisposable
    {
        Ms.Data.IDbCommand CommandType(DbCommandTypes dbCommandType);
        int Execute();
        T ExecuteReturnLastId<T>(string identityColumnName = null);
        Ms.Data.IDbCommand Parameter(string name, object value, DataTypes parameterType = 13, Ms.Data.ParameterDirection direction = 1, int size = 0);
        Ms.Data.IDbCommand ParameterOut(string name, DataTypes parameterType, int size = 0);
        Ms.Data.IDbCommand Parameters(params Ms.Data.Common.Parameter[] parameters);
        TParameterType ParameterValue<TParameterType>(string outputParameterName);
        [return: Dynamic(new bool[] { false, true })]
        List<object> Query();
        List<TEntity> Query<TEntity>(Action<TEntity, Ms.Data.IDataReader> customMapper = null);
        TList Query<TEntity, TList>(Action<TEntity, Ms.Data.IDataReader> customMapper = null) where TList: IList<TEntity>;
        [return: Dynamic]
        object QueryAndFeild();
        void QueryComplex<TEntity>(IList<TEntity> list, Action<IList<TEntity>, Ms.Data.IDataReader> customMapper);
        TEntity QueryComplexSingle<TEntity>(Func<Ms.Data.IDataReader, TEntity> customMapper);
        DataTable QueryDataTable();
        [return: Dynamic]
        object QuerySingle();
        TEntity QuerySingle<TEntity>(Action<TEntity, Ms.Data.IDataReader> customMapper = null);
        Ms.Data.IDbCommand Sql(string sql);

        DbCommandData Data { get; }
    }
}

