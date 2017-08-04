using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class FinanceDeliver : BaseProvider<T_Finance_Driver>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Finance_Driver> queryInfo)
        {
            return UIHelper.Resolve<IFinanceDriverDal>().Select(queryInfo);
        }

        protected override int GetTotal(QueryInfo<T_Finance_Driver> queryInfo)
        {
            return UIHelper.Resolve<IFinanceDriverDal>().GetTotal(queryInfo);
        }
    }
}