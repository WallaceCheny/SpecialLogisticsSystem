using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers.Provider
{
    public class FinanceGoods : BaseProvider<T_Finance_Goods>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Finance_Goods> queryInfo)
        {
            return UIHelper.Resolve<IFinanceGoodsDal>().Select(queryInfo);
        }

        protected override int GetTotal(QueryInfo<T_Finance_Goods> queryInfo)
        {
            return UIHelper.Resolve<IFinanceGoodsDal>().GetTotal(queryInfo);
        }
    }
}