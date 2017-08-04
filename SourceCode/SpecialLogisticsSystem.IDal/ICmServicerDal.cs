
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;
//服务商
namespace SpecialLogisticsSystem.IDal
{
    public interface ICmServicerDal
    {
        PagedList<T_Cm_Servicer> GetPageList(QueryInfo<T_Cm_Servicer> queryInfo);
        IList<T_Cm_Servicer> GetList(QueryInfo<T_Cm_Servicer> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Servicer> queryInfo);
        T_Cm_Servicer GetSingle(object id);
        int Insert(T_Cm_Servicer item);
        int Update(T_Cm_Servicer item);
        int Delete(List<object> ids);
    }
}