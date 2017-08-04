
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //送货明细
namespace SpecialLogisticsSystem.Dal
{
    public class ArrivalDeliverGoodsDal : IArrivalDeliverGoodsDal
    {
        private IDao _dao;
        public ArrivalDeliverGoodsDal(IDao dao) { _dao = dao; }
        public PagedList<T_Arrival_DeliverGoods> GetPageList(QueryInfo<T_Arrival_DeliverGoods> queryInfo)
        {
            return _dao.PagedList<T_Arrival_DeliverGoods>(queryInfo);
        }
        public IList<T_Arrival_DeliverGoods> GetList(QueryInfo<T_Arrival_DeliverGoods> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Arrival_DeliverGoods> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Arrival_DeliverGoods GetSingle(object id)
        {
            QueryInfo<T_Arrival_DeliverGoods> queryInfo = new QueryInfo<T_Arrival_DeliverGoods>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Arrival_DeliverGoods item)
        {
            return _dao.Insert<T_Arrival_DeliverGoods>(item);
        }
        public int Update(T_Arrival_DeliverGoods item)
        {
            return _dao.Update<T_Arrival_DeliverGoods>(item);
        }
        public int Delete(List<Guid> ids)
        {
            return _dao.Delete<T_Arrival_DeliverGoods>(new QueryInfo<T_Arrival_DeliverGoods>().SetQuery("ids", ids));
        }
        public int DeleteByDeliver(List<object> ids)
        {
            return _dao.Delete<T_Arrival_DeliverGoods>(new QueryInfo<T_Arrival_DeliverGoods>().SetXml("DeleteByDeliver").SetQuery("ids", ids));
        }
    }
}