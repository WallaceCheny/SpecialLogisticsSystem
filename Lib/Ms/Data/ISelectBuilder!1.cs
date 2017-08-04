namespace Ms.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;

    public interface ISelectBuilder<TEntity>
    {
        ISelectBuilder<TEntity> From(string sql);
        ISelectBuilder<TEntity> GroupBy(string sql);
        ISelectBuilder<TEntity> Having(string sql);
        ISelectBuilder<TEntity> OrderBy(string sql);
        ISelectBuilder<TEntity> Paging(int currentPage, int itemsPerPage);
        ISelectBuilder<TEntity> Parameter(string name, object value);
        List<TEntity> Query(Action<TEntity, IDataReader> customMapper = null);
        TList Query<TList>(Action<TEntity, IDataReader> customMapper = null) where TList: IList<TEntity>;
        void QueryComplex(IList<TEntity> list, Action<IList<TEntity>, IDataReader> customMapper);
        TEntity QueryComplexSingle(Func<IDataReader, TEntity> customMapper);
        TEntity QuerySingle(Action<TEntity, IDataReader> customMapper = null);
        ISelectBuilder<TEntity> Select(string sql);
        ISelectBuilder<TEntity> Select(string sql, Expression<Func<TEntity, object>> mapToProperty);
        ISelectBuilder<TEntity> Where(string sql);
        ISelectBuilder<TEntity> WhereAnd(string sql);
        ISelectBuilder<TEntity> WhereOr(string sql);
    }
}

