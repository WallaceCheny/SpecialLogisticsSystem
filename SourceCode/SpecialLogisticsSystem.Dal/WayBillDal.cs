
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //运单录入
namespace SpecialLogisticsSystem.Dal
{
    public class WayBillDal : IWayBillDal
    {
        private IDao _dao;
        public WayBillDal(IDao dao) { _dao = dao; }
        public int GetTotal(QueryInfo<T_Way_Bill> queryInfo)
        {
            return _dao.GetTotal<T_Way_Bill>(queryInfo);
        }
        public PagedList<T_Way_Bill> GetPageList(QueryInfo<T_Way_Bill> queryInfo)
        {
            return _dao.PagedList<T_Way_Bill>(queryInfo);
        }
        public IList<T_Way_Bill> GetList(QueryInfo<T_Way_Bill> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Way_Bill> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Way_Bill GetSingle(object id)
        {
            QueryInfo<T_Way_Bill> queryInfo = new QueryInfo<T_Way_Bill>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public T_Way_Bill GetSingleByNumber(string number)
        {
            QueryInfo<T_Way_Bill> queryInfo = new QueryInfo<T_Way_Bill>();
            queryInfo.SetQuery(T_Way_Bill.WayNumberColumnName,number);
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Way_Bill item)
        {
            return _dao.Insert<T_Way_Bill>(item);
        }
        public int Update(T_Way_Bill item)
        {
            return _dao.Update<T_Way_Bill>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Way_Bill>(new QueryInfo<T_Way_Bill>().SetQuery("ids", ids));
        }
    }
}