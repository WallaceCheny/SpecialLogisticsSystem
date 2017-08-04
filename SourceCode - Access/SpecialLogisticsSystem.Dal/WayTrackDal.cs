
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //运单追踪
namespace SpecialLogisticsSystem.Dal
{
    public class WayTrackDal : IWayTrackDal
    {
        private IDao _dao;
        public WayTrackDal(IDao dao) { _dao = dao; }
        public PagedList<T_Way_Track> GetPageList(QueryInfo<T_Way_Track> queryInfo)
        {
            return _dao.PagedList<T_Way_Track>(queryInfo);
        }
        public IList<T_Way_Track> GetList(QueryInfo<T_Way_Track> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Way_Track> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Way_Track GetSingle(object id)
        {
            QueryInfo<T_Way_Track> queryInfo = new QueryInfo<T_Way_Track>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Way_Track item)
        {
            return _dao.Insert<T_Way_Track>(item);
        }
        public int Update(T_Way_Track item)
        {
            return _dao.Update<T_Way_Track>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Way_Track>(new QueryInfo<T_Way_Track>().SetQuery("ids", ids));
        }
    }
}