
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmCodeDal
    {
        PagedList<T_Cm_Code> GetPageList(QueryInfo<T_Cm_Code> queryInfo);
        IList<T_Cm_Code> GetList(QueryInfo<T_Cm_Code> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Code> queryInfo);
        T_Cm_Code GetSingle(object id);
        int Insert(T_Cm_Code item);
        int Update(T_Cm_Code item);
        int Delete(List<object> ids);
    }
}