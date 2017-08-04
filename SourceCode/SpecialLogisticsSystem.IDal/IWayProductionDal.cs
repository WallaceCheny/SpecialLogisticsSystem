
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IWayProductionDal
    {
        PagedList<T_Way_Production> GetPageList(QueryInfo<T_Way_Production> queryInfo);
        IList<T_Way_Production> GetList(QueryInfo<T_Way_Production> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Way_Production> queryInfo);
        T_Way_Production GetSingle(object id);
        T_Way_Production GetSingleByWay(object id);
        int Insert(T_Way_Production item);
        int Update(T_Way_Production item);
        int Delete(List<object> ids);
        int DeleteByWay(object id);
    }
}