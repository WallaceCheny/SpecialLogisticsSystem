
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmFeeTypeDal
    {
        PagedList<T_Cm_FeeType> GetPageList(QueryInfo<T_Cm_FeeType> queryInfo);
        IList<T_Cm_FeeType> GetList(QueryInfo<T_Cm_FeeType> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_FeeType> queryInfo);
        T_Cm_FeeType GetSingle(object id);
        int Insert(T_Cm_FeeType item);
        int Update(T_Cm_FeeType item);
        int Delete(List<object> ids);
    }
}