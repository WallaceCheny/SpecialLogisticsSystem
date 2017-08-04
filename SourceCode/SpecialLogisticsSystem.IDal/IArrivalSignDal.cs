
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IArrivalSignDal
    {
        PagedList<T_Arrival_Sign> GetPageList(QueryInfo<T_Arrival_Sign> queryInfo);
        IList<T_Arrival_Sign> GetList(QueryInfo<T_Arrival_Sign> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Arrival_Sign> queryInfo);
        T_Arrival_Sign GetSingle(object id);
        int Insert(T_Arrival_Sign item);
        int Update(T_Arrival_Sign item);
        int Delete(List<object> ids);
    }
}