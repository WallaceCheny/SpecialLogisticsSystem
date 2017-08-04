
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //中转外包货物清单
namespace SpecialLogisticsSystem.Dal
{
    public class TransferDetailDal : ITransferDetailDal
    {
        private IDao _dao;
        public TransferDetailDal(IDao dao) { _dao = dao; }
        public PagedList<T_Transfer_Detail> GetPageList(QueryInfo<T_Transfer_Detail> queryInfo)
        {
            return _dao.PagedList<T_Transfer_Detail>(queryInfo);
        }
        public IList<T_Transfer_Detail> GetList(QueryInfo<T_Transfer_Detail> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Transfer_Detail> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Transfer_Detail GetSingle(object id)
        {
            QueryInfo<T_Transfer_Detail> queryInfo = new QueryInfo<T_Transfer_Detail>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Transfer_Detail item)
        {
            return _dao.Insert<T_Transfer_Detail>(item);
        }
        public int Update(T_Transfer_Detail item)
        {
            return _dao.Update<T_Transfer_Detail>(item);
        }
        public int Delete(List<Guid> ids)
        {
            return _dao.Delete<T_Transfer_Detail>(new QueryInfo<T_Transfer_Detail>().SetQuery("ids", ids));
        }
        public int DeleteByTransfer(List<object> ids)
        {
            return _dao.Delete<T_Transfer_Detail>(new QueryInfo<T_Transfer_Detail>().SetXml("DeleteByTransfer").SetQuery("ids", ids));
        }
    }
}