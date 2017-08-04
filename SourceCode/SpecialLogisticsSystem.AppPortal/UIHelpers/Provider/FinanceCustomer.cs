using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class FinanceCustomer:BaseProvider<T_Finance_Customer>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Finance_Customer> queryInfo)
        {
            return UIHelper.Resolve<IFinanceCustomerDal>().Select(queryInfo);
        }

        protected override int GetTotal(QueryInfo<T_Finance_Customer> queryInfo)
        {
            return UIHelper.Resolve<IFinanceCustomerDal>().GetTotal(queryInfo);
        }
    }
}