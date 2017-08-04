
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //角色信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmRoleDal : ICmRoleDal
    {
        private IDao _dao;
        public CmRoleDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Role> GetPageList(QueryInfo<T_Cm_Role> queryInfo)
        {
            return _dao.PagedList<T_Cm_Role>(queryInfo);
        }
        public IList<T_Cm_Role> GetList(QueryInfo<T_Cm_Role> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Role> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Role GetSingle(object id)
        {
            QueryInfo<T_Cm_Role> queryInfo = new QueryInfo<T_Cm_Role>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Role item)
        {
            return _dao.Insert<T_Cm_Role>(item);
        }
        public int Update(T_Cm_Role item)
        {
            return _dao.Update<T_Cm_Role>(item);
        }
        public int Delete(List<object> ids)
        {
            
            return _dao.Delete<T_Cm_Role>(new QueryInfo<T_Cm_Role>().SetQuery("ids", ids));
        }
    }
}