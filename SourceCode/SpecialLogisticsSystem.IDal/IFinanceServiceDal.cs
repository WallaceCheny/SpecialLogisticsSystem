
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IFinanceServiceDal
    {
        PagedList<T_Finance_Service> GetPageList(QueryInfo<T_Finance_Service> queryInfo);
        IList<T_Finance_Service> GetList(QueryInfo<T_Finance_Service> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Finance_Service> queryInfo);
        T_Finance_Service GetSingle(object id);
        int Insert(T_Finance_Service item);
        int Update(T_Finance_Service item);
        int Delete(List<object> ids);

        int GetTotal(QueryInfo<T_Finance_Service> queryInfo);
    }
}