
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IStowageSiteDal
    {
        PagedList<T_Stowage_Site> GetPageList(QueryInfo<T_Stowage_Site> queryInfo);
        IList<T_Stowage_Site> GetList(QueryInfo<T_Stowage_Site> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Stowage_Site> queryInfo);
        T_Stowage_Site GetSingle(object id);
        int Insert(T_Stowage_Site item);
        int Update(T_Stowage_Site item);
        int Delete(List<object> ids);
    }
}