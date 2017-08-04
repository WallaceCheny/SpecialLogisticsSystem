
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface IFinanceGoodsDal
    {
        PagedList<T_Finance_Goods> GetPageList(QueryInfo<T_Finance_Goods> queryInfo);
        IList<T_Finance_Goods> GetList(QueryInfo<T_Finance_Goods> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Finance_Goods> queryInfo);
        T_Finance_Goods GetSingle(object id);
        int Insert(T_Finance_Goods item);
        int Update(T_Finance_Goods item);
        int Delete(List<object> ids);

        int GetTotal(QueryInfo<T_Finance_Goods> queryInfo);
    }
}