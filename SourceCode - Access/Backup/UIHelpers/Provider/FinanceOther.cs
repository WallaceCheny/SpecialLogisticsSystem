using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class FinanceOther : BaseProvider<T_Finance_Daily>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Finance_Daily> queryInfo)
        {
            return UIHelper.Resolve<IFinanceDailyDal>().Select(queryInfo);
        }

        protected override int GetTotal(QueryInfo<T_Finance_Daily> queryInfo)
        {
            return UIHelper.Resolve<IFinanceDailyDal>().GetTotal(queryInfo);
        }
    }
}