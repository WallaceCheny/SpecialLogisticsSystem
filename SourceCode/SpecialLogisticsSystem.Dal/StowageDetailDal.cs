
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //专线配载货物明细
namespace SpecialLogisticsSystem.Dal
{
    public class StowageDetailDal : IStowageDetailDal
    {
        private IDao _dao;
        public StowageDetailDal(IDao dao) { _dao = dao; }
        public PagedList<T_Stowage_Detail> GetPageList(QueryInfo<T_Stowage_Detail> queryInfo)
        {
            return _dao.PagedList<T_Stowage_Detail>(queryInfo);
        }
        public IList<T_Stowage_Detail> GetList(QueryInfo<T_Stowage_Detail> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Stowage_Detail> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Stowage_Detail GetSingle(object id)
        {
            QueryInfo<T_Stowage_Detail> queryInfo = new QueryInfo<T_Stowage_Detail>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Stowage_Detail item)
        {
            return _dao.Insert<T_Stowage_Detail>(item);
        }
        public int Update(T_Stowage_Detail item)
        {
            return _dao.Update<T_Stowage_Detail>(item);
        }
        public int Delete(List<Guid> ids)
        {
            return _dao.Delete<T_Stowage_Detail>(new QueryInfo<T_Stowage_Detail>().SetQuery("ids", ids));
        }
        public int DeleteByStowage(List<object> ids)
        {
            return _dao.Delete<T_Stowage_Detail>(new QueryInfo<T_Stowage_Detail>().SetXml("DeleteByStowage").SetQuery("ids", ids));
        }
    }
}