
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmCityDal
    {
        PagedList<T_Cm_City> GetPageList(QueryInfo<T_Cm_City> queryInfo);
        IList<T_Cm_City> GetList(QueryInfo<T_Cm_City> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_City> queryInfo);
        T_Cm_City GetSingle(object id);
        int Insert(T_Cm_City item);
        int Update(T_Cm_City item);
        int Delete(List<object> ids);
    }
}