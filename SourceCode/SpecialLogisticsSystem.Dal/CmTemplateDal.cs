
using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
 //打印模版信息
namespace SpecialLogisticsSystem.Dal
{
    public class CmTemplateDal : ICmTemplateDal
    {
        private IDao _dao;
        public CmTemplateDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Template> GetPageList(QueryInfo<T_Cm_Template> queryInfo)
        {
            return _dao.PagedList<T_Cm_Template>(queryInfo);
        }
        public IList<T_Cm_Template> GetList(QueryInfo<T_Cm_Template> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Template> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Template GetSingle(object id)
        {
            QueryInfo<T_Cm_Template> queryInfo = new QueryInfo<T_Cm_Template>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Template item)
        {
            return _dao.Insert<T_Cm_Template>(item);
        }
        public int Update(T_Cm_Template item)
        {
            return _dao.Update<T_Cm_Template>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_Template>(new QueryInfo<T_Cm_Template>().SetQuery("ids", ids));
        }
    }
}