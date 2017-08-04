
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IFinanceCustomerDal
    {
        int GetTotal(QueryInfo<T_Finance_Customer> queryInfo);
        PagedList<T_Finance_Customer> GetPageList(QueryInfo<T_Finance_Customer> queryInfo);
        IList<T_Finance_Customer> GetList(QueryInfo<T_Finance_Customer> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Finance_Customer> queryInfo);
        T_Finance_Customer GetSingle(object id);
        int Insert(T_Finance_Customer item);
        int Update(T_Finance_Customer item);
        int Delete(List<object> ids);
    }
}