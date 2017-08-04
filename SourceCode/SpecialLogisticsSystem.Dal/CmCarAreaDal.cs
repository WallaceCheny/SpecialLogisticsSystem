
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //车牌前缀信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmCarAreaDal : ICmCarAreaDal
    {
        private IDao _dao;
        public CmCarAreaDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_CarArea> GetPageList(QueryInfo<T_Cm_CarArea> queryInfo)
        {
            return _dao.PagedList<T_Cm_CarArea>(queryInfo);
        }
        public IList<T_Cm_CarArea> GetList(QueryInfo<T_Cm_CarArea> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_CarArea> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_CarArea GetSingle(object id)
        {
            QueryInfo<T_Cm_CarArea> queryInfo = new QueryInfo<T_Cm_CarArea>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_CarArea item)
        {
            return _dao.Insert<T_Cm_CarArea>(item);
        }
        public int Update(T_Cm_CarArea item)
        {
            return _dao.Update<T_Cm_CarArea>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_CarArea>(new QueryInfo<T_Cm_CarArea>().SetQuery("ids", ids));
        }
    }
}