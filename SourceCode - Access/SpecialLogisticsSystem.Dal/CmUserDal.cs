
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
//用户信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmUserDal : ICmUserDal
    {
        private IDao _dao;
        public CmUserDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_User> GetPageList(QueryInfo<T_Cm_User> queryInfo)
        {
            return _dao.PagedList<T_Cm_User>(queryInfo);
        }
        public IList<T_Cm_User> GetList(QueryInfo<T_Cm_User> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_User> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_User GetSingle(object id)
        {
            QueryInfo<T_Cm_User> queryInfo = new QueryInfo<T_Cm_User>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_User item)
        {
            return _dao.Insert<T_Cm_User>(item);
        }
        public int Update(T_Cm_User item)
        {
            return _dao.Update<T_Cm_User>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_User>(new QueryInfo<T_Cm_User>().SetQuery("ids", ids));
        }
    }
}