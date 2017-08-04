using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //货款结算
namespace SpecialLogisticsSystem.Dal
{
    public class FinanceGoodsDal : IFinanceGoodsDal
    {
        private IDao _dao;
        public FinanceGoodsDal(IDao dao) { _dao = dao; }
        public PagedList<T_Finance_Goods> GetPageList(QueryInfo<T_Finance_Goods> queryInfo)
        {
            return _dao.PagedList<T_Finance_Goods>(queryInfo);
        }
        public IList<T_Finance_Goods> GetList(QueryInfo<T_Finance_Goods> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Finance_Goods> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Finance_Goods GetSingle(object id)
        {
            QueryInfo<T_Finance_Goods> queryInfo = new QueryInfo<T_Finance_Goods>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Finance_Goods item)
        {
            return _dao.Insert<T_Finance_Goods>(item);
        }
        public int Update(T_Finance_Goods item)
        {
            return _dao.Update<T_Finance_Goods>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Finance_Goods>(new QueryInfo<T_Finance_Goods>().SetQuery("ids", ids));
        }
        public int GetTotal(QueryInfo<T_Finance_Goods> queryInfo)
        {
            return _dao.GetTotal<T_Finance_Goods>(queryInfo);
        }
    }
}