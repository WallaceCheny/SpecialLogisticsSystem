
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //送货信息
namespace SpecialLogisticsSystem.Dal
{
    public class ArrivalDeliverDal : IArrivalDeliverDal
    {
        private IDao _dao;
        public ArrivalDeliverDal(IDao dao) { _dao = dao; }
        public PagedList<T_Arrival_Deliver> GetPageList(QueryInfo<T_Arrival_Deliver> queryInfo)
        {
            return _dao.PagedList<T_Arrival_Deliver>(queryInfo);
        }
        public IList<T_Arrival_Deliver> GetList(QueryInfo<T_Arrival_Deliver> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Arrival_Deliver> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Arrival_Deliver GetSingle(object id)
        {
            QueryInfo<T_Arrival_Deliver> queryInfo = new QueryInfo<T_Arrival_Deliver>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Arrival_Deliver item)
        {
            return _dao.Insert<T_Arrival_Deliver>(item);
        }
        public int Update(T_Arrival_Deliver item)
        {
            return _dao.Update<T_Arrival_Deliver>(item);
        }
        public int Delete(List<object> ids)
        {
            int result = 0;
            DBHelper dbHelper = DBHelper.Current;
            using (var db = dbHelper.IContext.UseTransaction(true))
            {
                ArrivalDeliverGoodsDal _detail = new ArrivalDeliverGoodsDal(_dao);
                result += _detail.DeleteByDeliver(ids);
                result += _dao.Delete<T_Arrival_Deliver>(new QueryInfo<T_Arrival_Deliver>().SetQuery("ids", ids));
                db.Commit();
            }
            return result;
        }

        public int GetTotal(QueryInfo<T_Arrival_Deliver> queryInfo)
        {
            return _dao.GetTotal<T_Arrival_Deliver>(queryInfo);
        }
    }
}