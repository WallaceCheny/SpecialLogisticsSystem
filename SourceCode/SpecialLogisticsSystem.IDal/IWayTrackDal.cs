
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IWayTrackDal
    {
        PagedList<T_Way_Track> GetPageList(QueryInfo<T_Way_Track> queryInfo);
        IList<T_Way_Track> GetList(QueryInfo<T_Way_Track> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Way_Track> queryInfo);
        T_Way_Track GetSingle(object id);
        int Insert(T_Way_Track item);
        int Update(T_Way_Track item);
        int Delete(List<object> ids);
    }
}