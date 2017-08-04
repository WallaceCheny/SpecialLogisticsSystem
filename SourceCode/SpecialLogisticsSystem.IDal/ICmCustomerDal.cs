
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmCustomerDal
    {
        PagedList<T_Cm_Customer> GetPageList(QueryInfo<T_Cm_Customer> queryInfo);
        IList<T_Cm_Customer> GetList(QueryInfo<T_Cm_Customer> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Customer> queryInfo);
        T_Cm_Customer GetSingle(object id);
        int Insert(T_Cm_Customer item);
        int Update(T_Cm_Customer item);
        int Delete(List<T_Cm_Customer> customerList);
        int DeleteBySender(object id);
        T_Cm_Customer GetSingleByName(string sender_name, CustomerType customerType);
        int Delete(List<object> link_ids, List<object> ids);
    }
}