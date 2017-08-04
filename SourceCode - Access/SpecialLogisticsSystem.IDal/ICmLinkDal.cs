
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmLinkDal
    {
        PagedList<T_Cm_Link> GetPageList(QueryInfo<T_Cm_Link> queryInfo);
        IList<T_Cm_Link> GetList(QueryInfo<T_Cm_Link> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Link> queryInfo);
        T_Cm_Link GetSingle(object id);
        int Insert(T_Cm_Link item);
        int Update(T_Cm_Link item);
        int Delete(List<object> ids);
    }
}