
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //用户角色配置
namespace SpecialLogisticsSystem.Dal
{
    public class CmUserRoleRelationDal : ICmUserRoleRelationDal
    {
        private IDao _dao;
        public CmUserRoleRelationDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_UserRole_Relation> GetPageList(QueryInfo<T_Cm_UserRole_Relation> queryInfo)
        {
            return _dao.PagedList<T_Cm_UserRole_Relation>(queryInfo);
        }
        public IList<T_Cm_UserRole_Relation> GetList(QueryInfo<T_Cm_UserRole_Relation> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_UserRole_Relation> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_UserRole_Relation GetSingle(object id)
        {
            QueryInfo<T_Cm_UserRole_Relation> queryInfo = new QueryInfo<T_Cm_UserRole_Relation>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_UserRole_Relation item)
        {
            return _dao.Insert<T_Cm_UserRole_Relation>(item);
        }
        public int Update(T_Cm_UserRole_Relation item)
        {
            return _dao.Update<T_Cm_UserRole_Relation>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_UserRole_Relation>(new QueryInfo<T_Cm_UserRole_Relation>().SetQuery("ids", ids));
        }
        public int DeleteByUsers(List<object> ids)
        {
            return _dao.Delete<T_Cm_UserRole_Relation>(new QueryInfo<T_Cm_UserRole_Relation>().SetXml("DeleteByUsers").SetQuery("ids", ids));
        }
    }
}