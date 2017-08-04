
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //省份信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmProvinceDal : ICmProvinceDal
    {
        private IDao _dao;
        public CmProvinceDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Province> GetPageList(QueryInfo<T_Cm_Province> queryInfo)
        {
            return _dao.PagedList<T_Cm_Province>(queryInfo);
        }
        public IList<T_Cm_Province> GetList(QueryInfo<T_Cm_Province> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Province> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Province GetSingle(object id)
        {
            QueryInfo<T_Cm_Province> queryInfo = new QueryInfo<T_Cm_Province>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Province item)
        {
            return _dao.Insert<T_Cm_Province>(item);
        }
        public int Update(T_Cm_Province item)
        {
            return _dao.Update<T_Cm_Province>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_Province>(new QueryInfo<T_Cm_Province>().SetQuery("ids", ids));
        }
    }
}