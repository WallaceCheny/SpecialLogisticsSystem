
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ITransferMainDal
    {
        PagedList<T_Transfer_Main> GetPageList(QueryInfo<T_Transfer_Main> queryInfo);
        IList<T_Transfer_Main> GetList(QueryInfo<T_Transfer_Main> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Transfer_Main> queryInfo);
        T_Transfer_Main GetSingle(object id);
        int Insert(T_Transfer_Main item);
        int Update(T_Transfer_Main item);
        int Delete(List<object> ids);

        int GetTotal(QueryInfo<T_Transfer_Main> queryInfo);
    }
}