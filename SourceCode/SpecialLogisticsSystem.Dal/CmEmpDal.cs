
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //员工基本信息录入表
namespace SpecialLogisticsSystem.Dal
{
    public class CmEmpDal : ICmEmpDal
    {
        private IDao _dao;
        public CmEmpDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Emp> GetPageList(QueryInfo<T_Cm_Emp> queryInfo)
        {
            return _dao.PagedList<T_Cm_Emp>(queryInfo);
        }
        public IList<T_Cm_Emp> GetList(QueryInfo<T_Cm_Emp> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Emp> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Emp GetSingle(object id)
        {
            QueryInfo<T_Cm_Emp> queryInfo = new QueryInfo<T_Cm_Emp>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Emp item)
        {
            return _dao.Insert<T_Cm_Emp>(item);
        }
        public int Update(T_Cm_Emp item)
        {
            return _dao.Update<T_Cm_Emp>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_Emp>(new QueryInfo<T_Cm_Emp>().SetQuery("ids", ids));
        }
    }
}