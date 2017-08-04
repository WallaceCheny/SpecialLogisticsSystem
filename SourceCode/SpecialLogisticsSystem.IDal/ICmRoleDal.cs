
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmRoleDal
    {
        PagedList<T_Cm_Role> GetPageList(QueryInfo<T_Cm_Role> queryInfo);
        IList<T_Cm_Role> GetList(QueryInfo<T_Cm_Role> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Role> queryInfo);
        T_Cm_Role GetSingle(object id);
        int Insert(T_Cm_Role item);
        int Update(T_Cm_Role item);
        int Delete(List<object> ids);
    }
}