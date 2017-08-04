
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //所在地区信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmDistrictDal : ICmDistrictDal
    {
        private IDao _dao;
        public CmDistrictDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_District> GetPageList(QueryInfo<T_Cm_District> queryInfo)
        {
            return _dao.PagedList<T_Cm_District>(queryInfo);
        }
        public IList<T_Cm_District> GetList(QueryInfo<T_Cm_District> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_District> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_District GetSingle(object id)
        {
            QueryInfo<T_Cm_District> queryInfo = new QueryInfo<T_Cm_District>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_District item)
        {
            return _dao.Insert<T_Cm_District>(item);
        }
        public int Update(T_Cm_District item)
        {
            return _dao.Update<T_Cm_District>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_District>(new QueryInfo<T_Cm_District>().SetQuery("ids", ids));
        }
    }
}