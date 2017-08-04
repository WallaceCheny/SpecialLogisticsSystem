
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;
//到货管理
namespace SpecialLogisticsSystem.IDal
{
    public interface IArrivalMainDal
    {
        int GetTotal(QueryInfo<T_Arrival_Main> queryInfo);
        PagedList<T_Arrival_Main> GetPageList(QueryInfo<T_Arrival_Main> queryInfo);
        IList<T_Arrival_Main> GetList(QueryInfo<T_Arrival_Main> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Arrival_Main> queryInfo);
        T_Arrival_Main GetSingle(object id);
        int Insert(T_Arrival_Main item);
        int Update(T_Arrival_Main item);
        int Delete(List<object> ids);

    }
}