
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IWayBillDal
    {
        int GetTotal(QueryInfo<T_Way_Bill> queryInfo);
        PagedList<T_Way_Bill> GetPageList(QueryInfo<T_Way_Bill> queryInfo);
        IList<T_Way_Bill> GetList(QueryInfo<T_Way_Bill> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Way_Bill> queryInfo);
        T_Way_Bill GetSingle(object id);
        T_Way_Bill GetSingleByNumber(string number);
        int Insert(T_Way_Bill item);
        int Update(T_Way_Bill item);
        int Delete(List<object> ids);
    }
}