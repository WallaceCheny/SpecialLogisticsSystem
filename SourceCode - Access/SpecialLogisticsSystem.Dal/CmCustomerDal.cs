using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using System.Linq;

//客户与收件人信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmCustomerDal : ICmCustomerDal
    {
        private IDao _dao;
        public CmCustomerDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Customer> GetPageList(QueryInfo<T_Cm_Customer> queryInfo)
        {
            return _dao.PagedList<T_Cm_Customer>(queryInfo);
        }
        public IList<T_Cm_Customer> GetList(QueryInfo<T_Cm_Customer> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Customer> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Customer GetSingle(object id)
        {
            QueryInfo<T_Cm_Customer> queryInfo = new QueryInfo<T_Cm_Customer>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public T_Cm_Customer GetSingleByName(string name, CustomerType type)
        {
            QueryInfo<T_Cm_Customer> queryInfo = new QueryInfo<T_Cm_Customer>();
            queryInfo.SetQuery(T_Cm_Customer.CustomerTypeColumnName, type.ToString());
            queryInfo.SetQuery(T_Cm_Customer.CustomerNameColumnName, name);
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Customer item)
        {
            int result = 0;
            DBHelper dbHelper = DBHelper.Current;
            using (var db = dbHelper.IContext.UseTransaction(true))
            {
                CmLinkDal _link = new CmLinkDal(_dao);
                result += _link.Insert(item.link);
                item.link_id = item.link.id;
                result += _dao.Insert<T_Cm_Customer>(item);
                db.Commit();
            }
            return result;
        }
        public int Update(T_Cm_Customer item)
        {
            int result = 0;
            DBHelper dbHelper = DBHelper.Current;
            using (var db = dbHelper.IContext.UseTransaction(true))
            {
                CmLinkDal _link = new CmLinkDal(_dao);
                result += _link.Update(item.link);
                item.link_id = item.link.id;
                result += _dao.Update<T_Cm_Customer>(item);
                db.Commit();
            }
            return result;// _dao.Update<T_Cm_Customer>(item);
        }
        public int Delete(List<object> link_ids, List<object> ids)
        {
            int result = 0;
            DBHelper dbHelper = DBHelper.Current;
            using (var db = dbHelper.IContext.UseTransaction(true))
            {
                CmLinkDal _link = new CmLinkDal(_dao);
                result += _link.Delete(link_ids);
                result += _dao.Delete<T_Cm_Customer>(new QueryInfo<T_Cm_Customer>().SetQuery("ids", ids));
                db.Commit();
            }
            return result;
        }
        public int Delete(List<T_Cm_Customer> customerList)
        {
            if (customerList.Count == 0) return 0;
            int result = 0;
            List<object> link_ids = new List<object>();
            foreach (var item in customerList)
            {
                link_ids.Add(item.link_id);
            }
            List<object> customer_ids = customerList.Select(p => p.id).Cast<object>().ToList();
            result = Delete(link_ids, customer_ids);
            return result;
        }
        public int DeleteBySender(object id)
        {
            QueryInfo<T_Cm_Customer> queryInfo = new QueryInfo<T_Cm_Customer>();
            queryInfo.SetQuery("sender_id", id);
            IList<T_Cm_Customer> customerList = _dao.GetList<T_Cm_Customer>(queryInfo);
            return Delete(customerList.ToList());
        }
    }
}