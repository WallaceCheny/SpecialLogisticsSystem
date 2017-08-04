
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
//到货管理
namespace SpecialLogisticsSystem.Dal
{
    public class ArrivalMainDal : IArrivalMainDal
    {
        private IDao _dao;
        public ArrivalMainDal(IDao dao) { _dao = dao; }
        public int GetTotal(QueryInfo<T_Arrival_Main> queryInfo)
        {
            return _dao.GetTotal<T_Arrival_Main>(queryInfo);
        }
        public PagedList<T_Arrival_Main> GetPageList(QueryInfo<T_Arrival_Main> queryInfo)
        {
            return _dao.PagedList<T_Arrival_Main>(queryInfo);
        }
        public IList<T_Arrival_Main> GetList(QueryInfo<T_Arrival_Main> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Arrival_Main> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Arrival_Main GetSingle(object id)
        {
            QueryInfo<T_Arrival_Main> queryInfo = new QueryInfo<T_Arrival_Main>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Arrival_Main item)
        {
            return _dao.Insert<T_Arrival_Main>(item);
        }
        public int Update(T_Arrival_Main item)
        {
            return _dao.Update<T_Arrival_Main>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Arrival_Main>(new QueryInfo<T_Arrival_Main>().SetQuery("ids", ids));
        }
    }
}