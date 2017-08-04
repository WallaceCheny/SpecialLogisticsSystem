
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //城市信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmCityDal : ICmCityDal
    {
        private IDao _dao;
        public CmCityDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_City> GetPageList(QueryInfo<T_Cm_City> queryInfo)
        {
            return _dao.PagedList<T_Cm_City>(queryInfo);
        }
        public IList<T_Cm_City> GetList(QueryInfo<T_Cm_City> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_City> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_City GetSingle(object id)
        {
            QueryInfo<T_Cm_City> queryInfo = new QueryInfo<T_Cm_City>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_City item)
        {
            return _dao.Insert<T_Cm_City>(item);
        }
        public int Update(T_Cm_City item)
        {
            return _dao.Update<T_Cm_City>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_City>(new QueryInfo<T_Cm_City>().SetQuery("ids", ids));
        }
    }
}