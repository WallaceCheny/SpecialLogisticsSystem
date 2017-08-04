
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //费用类别
namespace SpecialLogisticsSystem.Dal
{
    public class CmFeeTypeDal : ICmFeeTypeDal
    {
        private IDao _dao;
        public CmFeeTypeDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_FeeType> GetPageList(QueryInfo<T_Cm_FeeType> queryInfo)
        {
            return _dao.PagedList<T_Cm_FeeType>(queryInfo);
        }
        public IList<T_Cm_FeeType> GetList(QueryInfo<T_Cm_FeeType> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_FeeType> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_FeeType GetSingle(object id)
        {
            QueryInfo<T_Cm_FeeType> queryInfo = new QueryInfo<T_Cm_FeeType>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_FeeType item)
        {
            return _dao.Insert<T_Cm_FeeType>(item);
        }
        public int Update(T_Cm_FeeType item)
        {
            return _dao.Update<T_Cm_FeeType>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_FeeType>(new QueryInfo<T_Cm_FeeType>().SetQuery("ids", ids));
        }
    }
}