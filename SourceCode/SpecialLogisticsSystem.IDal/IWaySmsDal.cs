
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IWaySmsDal
    {
        PagedList<T_Way_Sms> GetPageList(QueryInfo<T_Way_Sms> queryInfo);
        IList<T_Way_Sms> GetList(QueryInfo<T_Way_Sms> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Way_Sms> queryInfo);
        T_Way_Sms GetSingle(object id);
        int Insert(T_Way_Sms item);
        int Update(T_Way_Sms item);
        int Delete(List<object> ids);
    }
}