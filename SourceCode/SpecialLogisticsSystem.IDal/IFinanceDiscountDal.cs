
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;
//回扣发放
namespace SpecialLogisticsSystem.IDal
{
    public interface IFinanceDiscountDal
    {
        int GetTotal(QueryInfo<T_Finance_Discount> queryInfo);
        PagedList<T_Finance_Discount> GetPageList(QueryInfo<T_Finance_Discount> queryInfo);
        IList<T_Finance_Discount> GetList(QueryInfo<T_Finance_Discount> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Finance_Discount> queryInfo);
        T_Finance_Discount GetSingle(object id);
        int Insert(T_Finance_Discount item);
        int Update(T_Finance_Discount item);
        int Delete(List<object> ids);

    }
}