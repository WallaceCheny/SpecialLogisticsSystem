
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //车辆信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmCarDal : ICmCarDal
    {
        private IDao _dao;
        public CmCarDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Car> GetPageList(QueryInfo<T_Cm_Car> queryInfo)
        {
            return _dao.PagedList<T_Cm_Car>(queryInfo);
        }
        public IList<T_Cm_Car> GetList(QueryInfo<T_Cm_Car> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Car> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Car GetSingle(object id)
        {
            QueryInfo<T_Cm_Car> queryInfo = new QueryInfo<T_Cm_Car>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Car item)
        {
            int result = 0;
            DBHelper dbHelper = DBHelper.Current;
            using (var db = dbHelper.IContext.UseTransaction(true))
            {
                CmLinkDal _link = new CmLinkDal(_dao);
                result += _link.Insert(item.link);
                result += _dao.Insert<T_Cm_Car>(item);
                db.Commit();
            }
            return result;
        }
        public int Update(T_Cm_Car item)
        {
            int result = 0;
            DBHelper dbHelper = DBHelper.Current;
            using (var db = dbHelper.IContext.UseTransaction(true))
            {
                CmLinkDal _link = new CmLinkDal(_dao);
                T_Cm_Link link= _link.GetSingle(item.car_link);
                if (null != link)
                {
                    result += _link.Update(item.link);
                }
                else
                {
                    result += _link.Insert(item.link);
                }
                result += _dao.Update<T_Cm_Car>(item);
                db.Commit();
            }
            return result;
        }
        public int Delete(List<object> ids)
        {
            //List<object> linkIds = new List<object>();

            //int result = 0;
            //DBHelper dbHelper = DBHelper.Current;
            //using (var db = dbHelper.IContext.UseTransaction(true))
            //{
            //    CmLinkDal _link = new CmLinkDal(_dao);
            //    result += _link.Delete(item);
            //    result += _dao.Update<T_Cm_Car>(item);
            //    db.Commit();
            //}
            //return result;
            return _dao.Delete<T_Cm_Car>(new QueryInfo<T_Cm_Car>().SetQuery("ids", ids));
        }
    }
}