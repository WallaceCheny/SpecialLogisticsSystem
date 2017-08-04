using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class FinanceAll : BaseProvider<T_Finance_Daily>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Finance_Daily> queryInfo)
        {
            return UIHelper.Resolve<IFinanceDailyDal>().Select(queryInfo);
        }

        protected override string GetXmlName()
        {
            return "SelectAll";
        }

        protected override int GetTotal(QueryInfo<T_Finance_Daily> queryInfo)
        {
            queryInfo.SetXml("CountAll");
            return UIHelper.Resolve<IFinanceDailyDal>().GetTotal(queryInfo);
        }
    }
}