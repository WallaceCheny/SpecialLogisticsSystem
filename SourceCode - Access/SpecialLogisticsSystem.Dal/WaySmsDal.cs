
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //运单短信通知
namespace SpecialLogisticsSystem.Dal
{
    public class WaySmsDal : IWaySmsDal
    {
        private IDao _dao;
        public WaySmsDal(IDao dao) { _dao = dao; }
        public PagedList<T_Way_Sms> GetPageList(QueryInfo<T_Way_Sms> queryInfo)
        {
            return _dao.PagedList<T_Way_Sms>(queryInfo);
        }
        public IList<T_Way_Sms> GetList(QueryInfo<T_Way_Sms> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Way_Sms> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Way_Sms GetSingle(object id)
        {
            QueryInfo<T_Way_Sms> queryInfo = new QueryInfo<T_Way_Sms>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Way_Sms item)
        {
            return _dao.Insert<T_Way_Sms>(item);
        }
        public int Update(T_Way_Sms item)
        {
            return _dao.Update<T_Way_Sms>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Way_Sms>(new QueryInfo<T_Way_Sms>().SetQuery("ids", ids));
        }
    }
}