using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using Newtonsoft.Json;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class WayProvider : BaseProvider<T_Way_Bill>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Way_Bill> queryInfo)
        {
            return UIHelper.Resolve<IWayBillDal>().Select(ConvertQuery(queryInfo));
        }

        protected override int GetTotal(QueryInfo<T_Way_Bill> queryInfo)
        {
            return UIHelper.Resolve<IWayBillDal>().GetTotal(ConvertQuery(queryInfo));
        }

        public QueryInfo<T_Way_Bill> ConvertQuery(QueryInfo<T_Way_Bill> queryInfo)
        {
            string strStatue=T_Way_Bill.StatueColumnName;
            if (queryInfo.Query.ContainsKey(strStatue)) queryInfo.Query[strStatue] = queryInfo.Query[strStatue].ToString().Split(Constants.splitChar);
            return queryInfo;
        }
    }
}