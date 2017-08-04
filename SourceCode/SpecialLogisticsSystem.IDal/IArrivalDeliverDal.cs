
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IArrivalDeliverDal
    {
        int GetTotal(QueryInfo<T_Arrival_Deliver> queryInfo);
        PagedList<T_Arrival_Deliver> GetPageList(QueryInfo<T_Arrival_Deliver> queryInfo);
        IList<T_Arrival_Deliver> GetList(QueryInfo<T_Arrival_Deliver> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Arrival_Deliver> queryInfo);
        T_Arrival_Deliver GetSingle(object id);
        int Insert(T_Arrival_Deliver item);
        int Update(T_Arrival_Deliver item);
        int Delete(List<object> ids);
    }
}