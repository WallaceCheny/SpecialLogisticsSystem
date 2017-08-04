
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IFinanceDailyDal
    {
        PagedList<T_Finance_Daily> GetPageList(QueryInfo<T_Finance_Daily> queryInfo);
        IList<T_Finance_Daily> GetList(QueryInfo<T_Finance_Daily> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Finance_Daily> queryInfo);
        T_Finance_Daily GetSingle(object id);
        int Insert(T_Finance_Daily item);
        int Update(T_Finance_Daily item);
        int Delete(List<object> ids);
        int GetTotal(QueryInfo<T_Finance_Daily> queryInfo);
    }
}