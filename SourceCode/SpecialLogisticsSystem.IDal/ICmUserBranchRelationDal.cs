
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmUserBranchRelationDal
    {
        PagedList<T_Cm_UserBranch_Relation> GetPageList(QueryInfo<T_Cm_UserBranch_Relation> queryInfo);
        IList<T_Cm_UserBranch_Relation> GetList(QueryInfo<T_Cm_UserBranch_Relation> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_UserBranch_Relation> queryInfo);
        T_Cm_UserBranch_Relation GetSingle(object id);
        int Insert(T_Cm_UserBranch_Relation item);
        int Update(T_Cm_UserBranch_Relation item);
        int Delete(List<object> ids);
        int DeleteByUsers(List<object> ids);
    }
}