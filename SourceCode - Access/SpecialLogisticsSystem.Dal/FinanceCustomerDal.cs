using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

//客户结算信息
namespace SpecialLogisticsSystem.Dal
{
    public class FinanceCustomerDal : IFinanceCustomerDal
    {
        private IDao _dao;
        public FinanceCustomerDal(IDao dao) { _dao = dao; }
        public PagedList<T_Finance_Customer> GetPageList(QueryInfo<T_Finance_Customer> queryInfo)
        {
            return _dao.PagedList<T_Finance_Customer>(queryInfo);
        }
        public IList<T_Finance_Customer> GetList(QueryInfo<T_Finance_Customer> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Finance_Customer> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Finance_Customer GetSingle(object id)
        {
            QueryInfo<T_Finance_Customer> queryInfo = new QueryInfo<T_Finance_Customer>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Finance_Customer item)
        {
            return _dao.Insert<T_Finance_Customer>(item);
        }
        public int Update(T_Finance_Customer item)
        {
            return _dao.Update<T_Finance_Customer>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Finance_Customer>(new QueryInfo<T_Finance_Customer>().SetQuery("ids", ids));
        }

        public int GetTotal(QueryInfo<T_Finance_Customer> queryInfo)
        {
            return _dao.GetTotal<T_Finance_Customer>(queryInfo);
        }
    }
}