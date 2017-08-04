using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //司机结算
namespace SpecialLogisticsSystem.Dal
{
    public class FinanceDriverDal : IFinanceDriverDal
    {
        private IDao _dao;
        public FinanceDriverDal(IDao dao) { _dao = dao; }
        public PagedList<T_Finance_Driver> GetPageList(QueryInfo<T_Finance_Driver> queryInfo)
        {
            return _dao.PagedList<T_Finance_Driver>(queryInfo);
        }
        public IList<T_Finance_Driver> GetList(QueryInfo<T_Finance_Driver> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Finance_Driver> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Finance_Driver GetSingle(object id)
        {
            QueryInfo<T_Finance_Driver> queryInfo = new QueryInfo<T_Finance_Driver>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Finance_Driver item)
        {
            return _dao.Insert<T_Finance_Driver>(item);
        }
        public int Update(T_Finance_Driver item)
        {
            return _dao.Update<T_Finance_Driver>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Finance_Driver>(new QueryInfo<T_Finance_Driver>().SetQuery("ids", ids));
        }
        public int GetTotal(QueryInfo<T_Finance_Driver> queryInfo)
        {
            return _dao.GetTotal<T_Finance_Driver>(queryInfo);
        }
    }
}