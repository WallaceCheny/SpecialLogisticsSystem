using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
//服务商
namespace SpecialLogisticsSystem.Dal
{
    public class CmServicerDal : ICmServicerDal
    {
        private IDao _dao;
        public CmServicerDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Servicer> GetPageList(QueryInfo<T_Cm_Servicer> queryInfo)
        {
            return _dao.PagedList<T_Cm_Servicer>(queryInfo);
        }
        public IList<T_Cm_Servicer> GetList(QueryInfo<T_Cm_Servicer> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Servicer> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Servicer GetSingle(object id)
        {
            QueryInfo<T_Cm_Servicer> queryInfo = new QueryInfo<T_Cm_Servicer>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Servicer item)
        {
            return _dao.Insert<T_Cm_Servicer>(item);
        }
        public int Update(T_Cm_Servicer item)
        {
            return _dao.Update<T_Cm_Servicer>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_Servicer>(new QueryInfo<T_Cm_Servicer>().SetQuery("ids", ids));
        }
    }
}