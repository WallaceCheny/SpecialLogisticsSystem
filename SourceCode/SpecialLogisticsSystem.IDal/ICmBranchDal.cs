
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmBranchDal
    {
        PagedList<T_Cm_Branch> GetPageList(QueryInfo<T_Cm_Branch> queryInfo);
        IList<T_Cm_Branch> GetList(QueryInfo<T_Cm_Branch> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Branch> queryInfo);
        T_Cm_Branch GetSingle(object id);
        int Insert(T_Cm_Branch item);
        int Update(T_Cm_Branch item);
        int Delete(List<object> ids);
    }
}