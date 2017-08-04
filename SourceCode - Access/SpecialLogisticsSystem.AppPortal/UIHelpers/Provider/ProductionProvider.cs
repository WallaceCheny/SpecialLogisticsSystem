using System.Collections.Generic;
using System.Linq;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class ProductionProvider
    {
        public List<dynamic> GetProduction()
        {
            QueryInfo<T_Way_Production> queryInfo = new QueryInfo<T_Way_Production>();
            //queryInfo.SetQuery("id", Guid.NewGuid().ToString());
            queryInfo.SetXml("SelectView");
            IWayProductionDal _production = UIHelper.Resolve<IWayProductionDal>();
            IList<dynamic> results = _production.Select(queryInfo);
            return results.ToList();
        }
    }
}