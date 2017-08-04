
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmConfigDal
    {
        PagedList<T_Cm_Config> GetPageList(QueryInfo<T_Cm_Config> queryInfo);
        IList<T_Cm_Config> GetList(QueryInfo<T_Cm_Config> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Config> queryInfo);
        T_Cm_Config GetSingle(object id);
        int Insert(T_Cm_Config item);
        int Update(T_Cm_Config item);
        int Delete(List<object> ids);
    }
}