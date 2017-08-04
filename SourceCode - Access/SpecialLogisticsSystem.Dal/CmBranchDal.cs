
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //公司网点
namespace SpecialLogisticsSystem.Dal
{
    public class CmBranchDal : ICmBranchDal
    {
        private IDao _dao;
        public CmBranchDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Branch> GetPageList(QueryInfo<T_Cm_Branch> queryInfo)
        {
            return _dao.PagedList<T_Cm_Branch>(queryInfo);
        }
        public IList<T_Cm_Branch> GetList(QueryInfo<T_Cm_Branch> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Branch> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Branch GetSingle(object id)
        {
            QueryInfo<T_Cm_Branch> queryInfo = new QueryInfo<T_Cm_Branch>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Branch item)
        {
            return _dao.Insert<T_Cm_Branch>(item);
        }
        public int Update(T_Cm_Branch item)
        {
            return _dao.Update<T_Cm_Branch>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_Branch>(new QueryInfo<T_Cm_Branch>().SetQuery("ids", ids));
        }
    }
}