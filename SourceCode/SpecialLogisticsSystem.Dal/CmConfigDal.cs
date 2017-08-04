
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //系统的配置参数
namespace SpecialLogisticsSystem.Dal
{
    public class CmConfigDal : ICmConfigDal
    {
        private IDao _dao;
        public CmConfigDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Config> GetPageList(QueryInfo<T_Cm_Config> queryInfo)
        {
            return _dao.PagedList<T_Cm_Config>(queryInfo);
        }
        public IList<T_Cm_Config> GetList(QueryInfo<T_Cm_Config> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Config> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Config GetSingle(object id)
        {
            QueryInfo<T_Cm_Config> queryInfo = new QueryInfo<T_Cm_Config>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Config item)
        {
            return _dao.Insert<T_Cm_Config>(item);
        }
        public int Update(T_Cm_Config item)
        {
            return _dao.Update<T_Cm_Config>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_Config>(new QueryInfo<T_Cm_Config>().SetQuery("ids", ids));
        }
    }
}