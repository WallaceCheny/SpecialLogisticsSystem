using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmMenuDal
    {
        PagedList<T_Cm_Menu> GetPageList(QueryInfo<T_Cm_Menu> queryInfo);
        IList<T_Cm_Menu> GetList(QueryInfo<T_Cm_Menu> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Menu> queryInfo);
        T_Cm_Menu GetSingle(object id);
        int Insert(T_Cm_Menu item);
        int Update(T_Cm_Menu item);
        int Delete(List<object> ids);
    }
}
