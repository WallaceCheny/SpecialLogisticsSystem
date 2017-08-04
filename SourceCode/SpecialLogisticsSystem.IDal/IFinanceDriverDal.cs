
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IFinanceDriverDal
    {
        PagedList<T_Finance_Driver> GetPageList(QueryInfo<T_Finance_Driver> queryInfo);
        IList<T_Finance_Driver> GetList(QueryInfo<T_Finance_Driver> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Finance_Driver> queryInfo);
        T_Finance_Driver GetSingle(object id);
        int Insert(T_Finance_Driver item);
        int Update(T_Finance_Driver item);
        int Delete(List<object> ids);
        int GetTotal(QueryInfo<T_Finance_Driver> queryInfo);
    }
}