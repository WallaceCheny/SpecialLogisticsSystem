using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.Dal
{
    public class CmMenuDal : ICmMenuDal
    {
        private IDao _dao;
        public CmMenuDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Menu> GetPageList(QueryInfo<T_Cm_Menu> queryInfo)
        {
            return _dao.PagedList<T_Cm_Menu>(queryInfo);
        }
        public IList<T_Cm_Menu> GetList(QueryInfo<T_Cm_Menu> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Menu> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Menu GetSingle(object id)
        {
            QueryInfo<T_Cm_Menu> queryInfo = new QueryInfo<T_Cm_Menu>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Menu item)
        {
            return _dao.Insert<T_Cm_Menu>(item);
        }
        public int Update(T_Cm_Menu item)
        {
            return _dao.Update<T_Cm_Menu>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_Menu>(new QueryInfo<T_Cm_Menu>().SetQuery("ids", ids));
        }
    }
}
