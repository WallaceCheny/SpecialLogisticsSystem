
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IStowageMainDal
    {
        PagedList<T_Stowage_Main> GetPageList(QueryInfo<T_Stowage_Main> queryInfo);
        IList<T_Stowage_Main> GetList(QueryInfo<T_Stowage_Main> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Stowage_Main> queryInfo);
        T_Stowage_Main GetSingle(object id);
        int Insert(T_Stowage_Main item);
        int Update(T_Stowage_Main item);
        int Delete(List<object> ids);
        int GetTotal(QueryInfo<T_Stowage_Main> queryInfo);
    }
}