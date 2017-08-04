
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //货物签收信息
namespace SpecialLogisticsSystem.Dal
{
    public class ArrivalSignDal : IArrivalSignDal
    {
        private IDao _dao;
        public ArrivalSignDal(IDao dao) { _dao = dao; }
        public PagedList<T_Arrival_Sign> GetPageList(QueryInfo<T_Arrival_Sign> queryInfo)
        {
            return _dao.PagedList<T_Arrival_Sign>(queryInfo);
        }
        public IList<T_Arrival_Sign> GetList(QueryInfo<T_Arrival_Sign> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Arrival_Sign> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Arrival_Sign GetSingle(object id)
        {
            QueryInfo<T_Arrival_Sign> queryInfo = new QueryInfo<T_Arrival_Sign>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Arrival_Sign item)
        {
            return _dao.Insert<T_Arrival_Sign>(item);
        }
        public int Update(T_Arrival_Sign item)
        {
            return _dao.Update<T_Arrival_Sign>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Arrival_Sign>(new QueryInfo<T_Arrival_Sign>().SetQuery("ids", ids));
        }
    }
}