
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;
using System;

namespace SpecialLogisticsSystem.IDal
{
    public interface ITransferDetailDal
    {
        PagedList<T_Transfer_Detail> GetPageList(QueryInfo<T_Transfer_Detail> queryInfo);
        IList<T_Transfer_Detail> GetList(QueryInfo<T_Transfer_Detail> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Transfer_Detail> queryInfo);
        T_Transfer_Detail GetSingle(object id);
        int Insert(T_Transfer_Detail item);
        int Update(T_Transfer_Detail item);
        int Delete(List<Guid> ids);
    }
}