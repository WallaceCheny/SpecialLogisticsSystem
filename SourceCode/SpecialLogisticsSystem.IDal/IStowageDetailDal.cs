
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;
using System;

namespace SpecialLogisticsSystem.IDal
{
    public interface IStowageDetailDal
    {
        PagedList<T_Stowage_Detail> GetPageList(QueryInfo<T_Stowage_Detail> queryInfo);
        IList<T_Stowage_Detail> GetList(QueryInfo<T_Stowage_Detail> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Stowage_Detail> queryInfo);
        T_Stowage_Detail GetSingle(object id);
        int Insert(T_Stowage_Detail item);
        int Update(T_Stowage_Detail item);
        int Delete(List<Guid> ids);
    }
}