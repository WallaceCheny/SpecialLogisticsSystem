
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmRoleMenuRelationDal
    {
        PagedList<T_Cm_RoleMenu_Relation> GetPageList(QueryInfo<T_Cm_RoleMenu_Relation> queryInfo);
        IList<T_Cm_RoleMenu_Relation> GetList(QueryInfo<T_Cm_RoleMenu_Relation> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_RoleMenu_Relation> queryInfo);
        T_Cm_RoleMenu_Relation GetSingle(object id);
        int Insert(T_Cm_RoleMenu_Relation item);
        int Update(T_Cm_RoleMenu_Relation item);
        int Delete(List<object> ids);
        int DeleteByRole(List<object> ids);
    }
}