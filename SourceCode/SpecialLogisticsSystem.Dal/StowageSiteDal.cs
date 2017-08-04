
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //专线配载途经站点
namespace SpecialLogisticsSystem.Dal
{
    public class StowageSiteDal : IStowageSiteDal
    {
        private IDao _dao;
        public StowageSiteDal(IDao dao) { _dao = dao; }
        public PagedList<T_Stowage_Site> GetPageList(QueryInfo<T_Stowage_Site> queryInfo)
        {
            return _dao.PagedList<T_Stowage_Site>(queryInfo);
        }
        public IList<T_Stowage_Site> GetList(QueryInfo<T_Stowage_Site> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Stowage_Site> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Stowage_Site GetSingle(object id)
        {
            QueryInfo<T_Stowage_Site> queryInfo = new QueryInfo<T_Stowage_Site>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Stowage_Site item)
        {
            return _dao.Insert<T_Stowage_Site>(item);
        }
        public int Update(T_Stowage_Site item)
        {
            return _dao.Update<T_Stowage_Site>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Stowage_Site>(new QueryInfo<T_Stowage_Site>().SetQuery("ids", ids));
        }
    }
}