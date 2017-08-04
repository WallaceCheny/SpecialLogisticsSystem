using System.Collections.Generic;
using Ms.Data;
using Ms.Data.Common;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IDao
    {
        IList<dynamic> Select(string name, string provider, string sql, params Parameter[] parameters);
        /// <summary>
        /// http://blog.csdn.net/jcx5083761/article/details/8552727
        /// </summary>
        /// <typeparam name="T">T必须要有一个无参构造函数</typeparam>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        int GetTotal<T>(QueryInfo<T> queryInfo) where T : Entity, new();
        T Single<T>(QueryInfo<T> queryInfo) where T : Entity, new();
        dynamic SingleDyn<T>(QueryInfo<T> queryInfo) where T : Entity, new();
        IList<T> GetList<T>(QueryInfo<T> queryInfo) where T : Entity, new();
        IList<dynamic> Select<T>(QueryInfo<T> queryInfo) where T : Entity, new();
        PagedList<T> PagedList<T>(QueryInfo<T> queryInfo) where T : Entity, new();
        int Batch(string sql, params Parameter[] parameters);
        int Batch<T>(List<T> entitys) where T : Entity, new();
        int Insert<T>(QueryInfo<T> queryInfo) where T : Entity, new();
        int Insert<T>(T entity) where T : Entity, new();    
        int Update<T>(QueryInfo<T> queryInfo) where T : Entity, new();
        int Update<T>(T entity) where T : Entity, new();
        int Delete<T>(QueryInfo<T> queryInfo) where T : Entity, new();
        int Delete<T>(T entity) where T : Entity, new();
        dynamic ModeltoDynamic<T>(T entity) where T : Entity, new();
        T DynamictoModel<T>(dynamic entity) where T : Entity, new();
        int GetPrimaryKey { get; }

        //20130803
        int Insert<T>(T entity, IDbContext context) where T : Entity, new();
        int Update<T>(T entity, IDbContext context) where T : Entity, new();
        int Batch<T>(List<T> entitys, IDbContext context) where T : Entity, new();
        int Delete<T>(QueryInfo<T> queryInfo, IDbContext context) where T : Entity, new();
    }
}
