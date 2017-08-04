using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
//日常财务结算
namespace SpecialLogisticsSystem.Dal
{
    public class FinanceDailyDal : IFinanceDailyDal
    {
        private IDao _dao;
        public FinanceDailyDal(IDao dao) { _dao = dao; }
        public PagedList<T_Finance_Daily> GetPageList(QueryInfo<T_Finance_Daily> queryInfo)
        {
            return _dao.PagedList<T_Finance_Daily>(queryInfo);
        }
        public IList<T_Finance_Daily> GetList(QueryInfo<T_Finance_Daily> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Finance_Daily> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Finance_Daily GetSingle(object id)
        {
            QueryInfo<T_Finance_Daily> queryInfo = new QueryInfo<T_Finance_Daily>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Finance_Daily item)
        {
            return _dao.Insert<T_Finance_Daily>(item);
        }
        public int Update(T_Finance_Daily item)
        {
            return _dao.Update<T_Finance_Daily>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Finance_Daily>(new QueryInfo<T_Finance_Daily>().SetQuery("ids", ids));
        }
        public int GetTotal(QueryInfo<T_Finance_Daily> queryInfo)
        {
            return _dao.GetTotal<T_Finance_Daily>(queryInfo);
        }
    }
}