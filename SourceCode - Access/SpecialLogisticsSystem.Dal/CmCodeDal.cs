using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

 //公共代码，属性，数据字典
namespace SpecialLogisticsSystem.Dal
{
    public class CmCodeDal : ICmCodeDal
    {
        private IDao _dao;
        public CmCodeDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_Code> GetPageList(QueryInfo<T_Cm_Code> queryInfo)
        {
            return _dao.PagedList<T_Cm_Code>(queryInfo);
        }
        public IList<T_Cm_Code> GetList(QueryInfo<T_Cm_Code> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_Code> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_Code GetSingle(object id)
        {
            QueryInfo<T_Cm_Code> queryInfo = new QueryInfo<T_Cm_Code>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_Code item)
        {
            return _dao.Insert<T_Cm_Code>(item);
        }
        public int Update(T_Cm_Code item)
        {
            return _dao.Update<T_Cm_Code>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_Code>(new QueryInfo<T_Cm_Code>().SetQuery("ids", ids));
        }
    }
}