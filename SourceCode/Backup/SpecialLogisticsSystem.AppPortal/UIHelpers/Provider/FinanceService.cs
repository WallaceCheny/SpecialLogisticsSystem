using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class FinanceService : BaseProvider<T_Finance_Service>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Finance_Service> queryInfo)
        {
            return UIHelper.Resolve<IFinanceServiceDal>().Select(queryInfo);
        }

        protected override int GetTotal(QueryInfo<T_Finance_Service> queryInfo)
        {
            return UIHelper.Resolve<IFinanceServiceDal>().GetTotal(queryInfo);
        }
    }
}