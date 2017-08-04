
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //服务商结算
namespace SpecialLogisticsSystem.Dal
{
    public class FinanceServiceDal : IFinanceServiceDal
    {
        private IDao _dao;
        public FinanceServiceDal(IDao dao) { _dao = dao; }
        public PagedList<T_Finance_Service> GetPageList(QueryInfo<T_Finance_Service> queryInfo)
        {
            return _dao.PagedList<T_Finance_Service>(queryInfo);
        }
        public IList<T_Finance_Service> GetList(QueryInfo<T_Finance_Service> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Finance_Service> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Finance_Service GetSingle(object id)
        {
            QueryInfo<T_Finance_Service> queryInfo = new QueryInfo<T_Finance_Service>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Finance_Service item)
        {
            return _dao.Insert<T_Finance_Service>(item);
        }
        public int Update(T_Finance_Service item)
        {
            return _dao.Update<T_Finance_Service>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Finance_Service>(new QueryInfo<T_Finance_Service>().SetQuery("ids", ids));
        }
        public int GetTotal(QueryInfo<T_Finance_Service> queryInfo)
        {
            return _dao.GetTotal<T_Finance_Service>(queryInfo);
        }
    }
}