
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //菜单与角色权限
namespace SpecialLogisticsSystem.Dal
{
    public class CmRoleMenuRelationDal : ICmRoleMenuRelationDal
    {
        private IDao _dao;
        public CmRoleMenuRelationDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_RoleMenu_Relation> GetPageList(QueryInfo<T_Cm_RoleMenu_Relation> queryInfo)
        {
            return _dao.PagedList<T_Cm_RoleMenu_Relation>(queryInfo);
        }
        public IList<T_Cm_RoleMenu_Relation> GetList(QueryInfo<T_Cm_RoleMenu_Relation> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_RoleMenu_Relation> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_RoleMenu_Relation GetSingle(object id)
        {
            QueryInfo<T_Cm_RoleMenu_Relation> queryInfo = new QueryInfo<T_Cm_RoleMenu_Relation>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_RoleMenu_Relation item)
        {
            return _dao.Insert<T_Cm_RoleMenu_Relation>(item);
        }
        public int Update(T_Cm_RoleMenu_Relation item)
        {
            return _dao.Update<T_Cm_RoleMenu_Relation>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_RoleMenu_Relation>(new QueryInfo<T_Cm_RoleMenu_Relation>().SetQuery("ids", ids));
        }
        /// <summary>
        /// 根据角色删除跟菜单关联
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteByRole(List<object> ids)
        {
            return _dao.Delete<T_Cm_RoleMenu_Relation>(new QueryInfo<T_Cm_RoleMenu_Relation>().SetXml("DeleteByRole").SetQuery("role_ids", ids));
        }
    }
}