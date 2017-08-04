using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;


namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class FinanceDiscount : BaseProvider<T_Finance_Discount>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Finance_Discount> queryInfo)
        {
            return UIHelper.Resolve<IFinanceDiscountDal>().Select(queryInfo);
        }

        protected override int GetTotal(QueryInfo<T_Finance_Discount> queryInfo)
        {
            return UIHelper.Resolve<IFinanceDiscountDal>().GetTotal(queryInfo);
        }
    }
}