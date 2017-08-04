
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmUserRoleRelationDal
    {
        PagedList<T_Cm_UserRole_Relation> GetPageList(QueryInfo<T_Cm_UserRole_Relation> queryInfo);
        IList<T_Cm_UserRole_Relation> GetList(QueryInfo<T_Cm_UserRole_Relation> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_UserRole_Relation> queryInfo);
        T_Cm_UserRole_Relation GetSingle(object id);
        int Insert(T_Cm_UserRole_Relation item);
        int Update(T_Cm_UserRole_Relation item);
        int Delete(List<object> ids);
        int DeleteByUsers(List<object> ids);
    }
}