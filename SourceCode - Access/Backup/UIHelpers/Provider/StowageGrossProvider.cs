using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using Newtonsoft.Json;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class StowageGrossProvider : BaseProvider<T_Stowage_Main>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Stowage_Main> queryInfo)
        {
            return UIHelper.Resolve<IStowageMainDal>().Select(queryInfo);
        }

        protected override string GetXmlName()
        {
            return "SelectGross";
        }

        protected override int GetTotal(QueryInfo<T_Stowage_Main> queryInfo)
        {
            queryInfo.SetXml("CountGross");
            return UIHelper.Resolve<IStowageMainDal>().GetTotal(queryInfo);
        }
    }
}