
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //中转外包
namespace SpecialLogisticsSystem.Dal
{
    public class TransferMainDal : ITransferMainDal
    {
        private IDao _dao;
        public TransferMainDal(IDao dao) { _dao = dao; }
        public PagedList<T_Transfer_Main> GetPageList(QueryInfo<T_Transfer_Main> queryInfo)
        {
            return _dao.PagedList<T_Transfer_Main>(queryInfo);
        }
        public IList<T_Transfer_Main> GetList(QueryInfo<T_Transfer_Main> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Transfer_Main> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Transfer_Main GetSingle(object id)
        {
            QueryInfo<T_Transfer_Main> queryInfo = new QueryInfo<T_Transfer_Main>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Transfer_Main item)
        {
            return _dao.Insert<T_Transfer_Main>(item);
        }
        public int Update(T_Transfer_Main item)
        {
            return _dao.Update<T_Transfer_Main>(item);
        }
        public int Delete(List<object> ids)
        {
            int result = 0;
            DBHelper dbHelper = DBHelper.Current;
            using (var db = dbHelper.IContext.UseTransaction(true))
            {
                TransferDetailDal _detail = new TransferDetailDal(_dao);
                result += _detail.DeleteByTransfer(ids);
                result += _dao.Delete<T_Transfer_Main>(new QueryInfo<T_Transfer_Main>().SetQuery("ids", ids));
                db.Commit();
            }
            return result;
        }
        public int GetTotal(QueryInfo<T_Transfer_Main> queryInfo)
        {
            return _dao.GetTotal<T_Transfer_Main>(queryInfo);
        }
    }
}