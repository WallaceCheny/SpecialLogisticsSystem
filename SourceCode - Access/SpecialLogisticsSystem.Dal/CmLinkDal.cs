
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //联系人信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmLinkDal : ICmLinkDal
    {
        private IDao _dao;
        public CmLinkDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Link> GetPageList(QueryInfo<T_Cm_Link> queryInfo)
        {
            return _dao.PagedList<T_Cm_Link>(queryInfo);
        }
        public IList<T_Cm_Link> GetList(QueryInfo<T_Cm_Link> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Link> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Link GetSingle(object id)
        {
            QueryInfo<T_Cm_Link> queryInfo = new QueryInfo<T_Cm_Link>();
            queryInfo.PrimaryKeyValue = id;
            T_Cm_Link link= _dao.Single(queryInfo);
            return link;
        }
        public int Insert(T_Cm_Link item)
        {
            return _dao.Insert<T_Cm_Link>(item);
        }
        public int Update(T_Cm_Link item)
        {
            return _dao.Update<T_Cm_Link>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_Link>(new QueryInfo<T_Cm_Link>().SetQuery("ids", ids));
        }
    }
}