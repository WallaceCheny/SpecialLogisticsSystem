
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using System.Linq;

 //运单货物
namespace SpecialLogisticsSystem.Dal
{
    public class WayProductionDal : IWayProductionDal
    {
        private IDao _dao;
        public WayProductionDal(IDao dao) { _dao = dao; }
        public PagedList<T_Way_Production> GetPageList(QueryInfo<T_Way_Production> queryInfo)
        {
            return _dao.PagedList<T_Way_Production>(queryInfo);
        }
        public IList<T_Way_Production> GetList(QueryInfo<T_Way_Production> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Way_Production> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Way_Production GetSingle(object id)
        {
            QueryInfo<T_Way_Production> queryInfo = new QueryInfo<T_Way_Production>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Way_Production item)
        {
            return _dao.Insert<T_Way_Production>(item);
        }
        public int Update(T_Way_Production item)
        {
            return _dao.Update<T_Way_Production>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Way_Production>(new QueryInfo<T_Way_Production>().SetQuery("ids", ids));
        }
        /// <summary>
        /// 删除托运单下的所有货物
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteByWay(object id)
        {
            List<Guid> ids = new List<Guid>();
            IList<T_Way_Production> productionList=GetList(new QueryInfo<T_Way_Production>().SetQuery("bill_id", id));
            foreach (var item in productionList)
            {
                ids.Add(item.id);
            }
            if (ids.Count == 0) return 0;
            return _dao.Delete<T_Way_Production>(new QueryInfo<T_Way_Production>().SetQuery("ids", ids));
        }


        public T_Way_Production GetSingleByWay(object id)
        {
            QueryInfo<T_Way_Production> queryInfo = new QueryInfo<T_Way_Production>().SetQuery(T_Way_Production.BillIdColumnName, id);
            return _dao.GetList(queryInfo).FirstOrDefault();
        }
    }
}