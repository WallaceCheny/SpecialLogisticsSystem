namespace Ms.Data
{
    using System;
    using System.Dynamic;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;

    public interface IDbContext : IDisposable
    {
        IDbContext CommandTimeout(int timeout);
        IDbContext Commit();
        IDbContext ConnectionString(string connectionString, DbProviderTypes dbProviderType);
        IDbContext ConnectionString(string connectionString, IDbProvider dbProvider);
        IDbContext ConnectionStringName(string connectionstringName, DbProviderTypes dbProviderType);
        IDbContext ConnectionStringName(string connectionstringName, IDbProvider dbProvider);
        IDeleteBuilder Delete(string tableName);
        IDeleteBuilder<T> Delete<T>(string tableName, T item);
        IDbContext EntityFactory(IEntityFactory entityFactory);
        IInsertBuilder Insert(string tableName);
        IInsertBuilder<T> Insert<T>(string tableName, T item);
        IInsertBuilderDynamic Insert(string tableName, ExpandoObject item);
        IDbContext IsolationLevel(Ms.Data.IsolationLevel isolationLevel);
        IDbCommand MultiResultSql(string sql = "", params object[] parameters);
        IStoredProcedureBuilder MultiResultStoredProcedure(string storedProcedureName);
        IStoredProcedureBuilderDynamic MultiResultStoredProcedure(string storedProcedureName, ExpandoObject item);
        IStoredProcedureBuilder<T> MultiResultStoredProcedure<T>(string storedProcedureName, T item);
        IDbContext OnConnectionClosed(Action<OnConnectionClosedEventArgs> action);
        IDbContext OnConnectionOpened(Action<OnConnectionOpenedEventArgs> action);
        IDbContext OnConnectionOpening(Action<OnConnectionOpeningEventArgs> action);
        IDbContext OnError(Action<OnErrorEventArgs> action);
        IDbContext OnExecuted(Action<OnExecutedEventArgs> action);
        IDbContext OnExecuting(Action<OnExecutingEventArgs> action);
        IDbContext Rollback();
        ISelectBuilder<TEntity> Select<TEntity>(string sql);
        ISelectBuilder<TEntity> Select<TEntity>(string sql, Expression<Func<TEntity, object>> mapToProperty);
        IDbCommand Sql(string sql, params object[] parameters);
        IStoredProcedureBuilder StoredProcedure(string storedProcedureName);
        IStoredProcedureBuilderDynamic StoredProcedure(string storedProcedureName, ExpandoObject item);
        IStoredProcedureBuilder<T> StoredProcedure<T>(string storedProcedureName, T item);
        IUpdateBuilder Update(string tableName);
        IUpdateBuilder<T> Update<T>(string tableName, T item);
        IUpdateBuilderDynamic Update(string tableName, ExpandoObject item);
        IDbContext UseSharedConnection(bool useSharedConnection);
        IDbContext UseTransaction(bool useTransaction);

        DbContextData Data { get; }

        IDbContext IgnoreIfAutoMapFails { get; }
    }
}

