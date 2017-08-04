
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;
using System;

namespace SpecialLogisticsSystem.IDal
{
    public interface IArrivalDeliverGoodsDal
    {
        PagedList<T_Arrival_DeliverGoods> GetPageList(QueryInfo<T_Arrival_DeliverGoods> queryInfo);
        IList<T_Arrival_DeliverGoods> GetList(QueryInfo<T_Arrival_DeliverGoods> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Arrival_DeliverGoods> queryInfo);
        T_Arrival_DeliverGoods GetSingle(object id);
        int Insert(T_Arrival_DeliverGoods item);
        int Update(T_Arrival_DeliverGoods item);
        int Delete(List<Guid> ids);
    }
}