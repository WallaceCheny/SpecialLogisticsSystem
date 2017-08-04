using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

//回扣发放
namespace SpecialLogisticsSystem.Dal
{
    public class FinanceDiscountDal : IFinanceDiscountDal
    {
        private IDao _dao;
        public FinanceDiscountDal(IDao dao) { _dao = dao; }
        public int GetTotal(QueryInfo<T_Finance_Discount> queryInfo)
        {
            return _dao.GetTotal<T_Finance_Discount>(queryInfo);
        }
        public PagedList<T_Finance_Discount> GetPageList(QueryInfo<T_Finance_Discount> queryInfo)
        {
            return _dao.PagedList<T_Finance_Discount>(queryInfo);
        }
        public IList<T_Finance_Discount> GetList(QueryInfo<T_Finance_Discount> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Finance_Discount> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Finance_Discount GetSingle(object id)
        {
            QueryInfo<T_Finance_Discount> queryInfo = new QueryInfo<T_Finance_Discount>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Finance_Discount item)
        {
            return _dao.Insert<T_Finance_Discount>(item);
        }
        public int Update(T_Finance_Discount item)
        {
            return _dao.Update<T_Finance_Discount>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Finance_Discount>(new QueryInfo<T_Finance_Discount>().SetQuery("ids", ids));
        }
    }
}