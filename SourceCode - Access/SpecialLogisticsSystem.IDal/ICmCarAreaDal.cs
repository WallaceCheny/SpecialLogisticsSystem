
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmCarAreaDal
    {
        PagedList<T_Cm_CarArea> GetPageList(QueryInfo<T_Cm_CarArea> queryInfo);
        IList<T_Cm_CarArea> GetList(QueryInfo<T_Cm_CarArea> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_CarArea> queryInfo);
        T_Cm_CarArea GetSingle(object id);
        int Insert(T_Cm_CarArea item);
        int Update(T_Cm_CarArea item);
        int Delete(List<object> ids);
    }
}