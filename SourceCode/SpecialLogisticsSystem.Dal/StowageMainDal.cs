
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //专线配载信息
namespace SpecialLogisticsSystem.Dal
{
    public class StowageMainDal : IStowageMainDal
    {
        private IDao _dao;
        public StowageMainDal(IDao dao) { _dao = dao; }
        public PagedList<T_Stowage_Main> GetPageList(QueryInfo<T_Stowage_Main> queryInfo)
        {
            return _dao.PagedList<T_Stowage_Main>(queryInfo);
        }
        public IList<T_Stowage_Main> GetList(QueryInfo<T_Stowage_Main> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Stowage_Main> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Stowage_Main GetSingle(object id)
        {
            QueryInfo<T_Stowage_Main> queryInfo = new QueryInfo<T_Stowage_Main>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Stowage_Main item)
        {
            return _dao.Insert<T_Stowage_Main>(item);
        }
        public int Update(T_Stowage_Main item)
        {
            return _dao.Update<T_Stowage_Main>(item);
        }
        public int Delete(List<object> ids)
        {
             int result = 0;
             DBHelper dbHelper = DBHelper.Current;
             using (var db = dbHelper.IContext.UseTransaction(true))
             {
                 StowageDetailDal _detail = new StowageDetailDal(_dao);
                 result += _detail.DeleteByStowage(ids);
                 result+= _dao.Delete<T_Stowage_Main>(new QueryInfo<T_Stowage_Main>().SetQuery("ids", ids));
                 db.Commit();
             }
             return result;
        }

        public int GetTotal(QueryInfo<T_Stowage_Main> queryInfo)
        {
            return _dao.GetTotal<T_Stowage_Main>(queryInfo);
        }
    }
}