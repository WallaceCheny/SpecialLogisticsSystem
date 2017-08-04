using System;
using System.Linq;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class DeliverDetailTemporary : BaseTemporary<T_Arrival_DeliverGoods>
    {
        public override string SessionName
        {
            get { return Constants.DeliverDetail; }
        }

        public override T_Arrival_DeliverGoods GetMode(string id)
        {
            T_Way_Production production = GetProduction(id);
            T_Arrival_DeliverGoods detail = new T_Arrival_DeliverGoods
            {
                id = Guid.NewGuid(),
                production_id = production.id,
                send_bill = production.delivery_expense
            };
            return detail;
        }

        public override Guid GetId(T_Arrival_DeliverGoods model)
        {
            return model.id;
        }

        public override bool IsExit(string id)
        {
            return GetList().Count(p => p.production_id ==GetProduction(id).id) > 0;
        }

        private T_Way_Production GetProduction(string id)
        {
            IWayProductionDal _way_production = UIHelper.Resolve<IWayProductionDal>();
            T_Way_Production production = _way_production.GetSingleByWay(id);
            return production;
        }
    }
}