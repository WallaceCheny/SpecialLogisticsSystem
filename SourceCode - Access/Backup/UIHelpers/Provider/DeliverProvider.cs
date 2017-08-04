using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using Newtonsoft.Json;


namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class DeliverProvider : BaseProvider<T_Arrival_Deliver>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Arrival_Deliver> queryInfo)
        {
            return UIHelper.Resolve<IArrivalDeliverDal>().Select(queryInfo);
        }

        protected override int GetTotal(QueryInfo<T_Arrival_Deliver> queryInfo)
        {
            return UIHelper.Resolve<IArrivalDeliverDal>().GetTotal(queryInfo);
        }
    }
}