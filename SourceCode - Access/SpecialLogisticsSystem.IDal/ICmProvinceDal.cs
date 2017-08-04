
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmProvinceDal
    {
        PagedList<T_Cm_Province> GetPageList(QueryInfo<T_Cm_Province> queryInfo);
        IList<T_Cm_Province> GetList(QueryInfo<T_Cm_Province> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Province> queryInfo);
        T_Cm_Province GetSingle(object id);
        int Insert(T_Cm_Province item);
        int Update(T_Cm_Province item);
        int Delete(List<object> ids);
    }
}