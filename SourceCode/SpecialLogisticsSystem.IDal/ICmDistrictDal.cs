
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmDistrictDal
    {
        PagedList<T_Cm_District> GetPageList(QueryInfo<T_Cm_District> queryInfo);
        IList<T_Cm_District> GetList(QueryInfo<T_Cm_District> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_District> queryInfo);
        T_Cm_District GetSingle(object id);
        int Insert(T_Cm_District item);
        int Update(T_Cm_District item);
        int Delete(List<object> ids);
    }
}