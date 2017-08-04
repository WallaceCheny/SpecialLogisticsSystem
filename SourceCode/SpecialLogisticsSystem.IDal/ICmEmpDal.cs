
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmEmpDal
    {
        PagedList<T_Cm_Emp> GetPageList(QueryInfo<T_Cm_Emp> queryInfo);
        IList<T_Cm_Emp> GetList(QueryInfo<T_Cm_Emp> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Emp> queryInfo);
        T_Cm_Emp GetSingle(object id);
        int Insert(T_Cm_Emp item);
        int Update(T_Cm_Emp item);
        int Delete(List<object> ids);
    }
}