using System;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class ProductionTemporary : BaseTemporary<T_Way_Production>
    {
        public override string SessionName
        {
            get { return Constants.ProductionDetail; }
        }

        public override T_Way_Production GetMode(string id)
        {
            IWayProductionDal _way_production = UIHelper.Resolve<IWayProductionDal>();
            QueryInfo<T_Way_Production> queryInfo = new QueryInfo<T_Way_Production>().SetQuery(T_Way_Production.BillIdColumnName, id);
            T_Way_Production production = new T_Way_Production() { 
                 id=Guid.NewGuid(),
            };
            return production;
        }

        public override Guid GetId(T_Way_Production model)
        {
            return model.id;
        }

        public override bool IsExit(string id)
        {
            return false;
        }
    }
}