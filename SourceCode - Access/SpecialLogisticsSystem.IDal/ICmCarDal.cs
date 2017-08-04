
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmCarDal
    {
        PagedList<T_Cm_Car> GetPageList(QueryInfo<T_Cm_Car> queryInfo);
        IList<T_Cm_Car> GetList(QueryInfo<T_Cm_Car> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Car> queryInfo);
        T_Cm_Car GetSingle(object id);
        int Insert(T_Cm_Car item);
        int Update(T_Cm_Car item);
        int Delete(List<object> ids);
    }
}