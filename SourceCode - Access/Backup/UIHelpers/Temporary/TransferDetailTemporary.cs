using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class TransferDetailTemporary : BaseTemporary<T_Transfer_Detail>
    {
        public override string SessionName
        {
            get { return Constants.TransferDetail; }
        }

        public override T_Transfer_Detail GetMode(string id)
        {
            T_Way_Production production = GetProduction(id);
            T_Transfer_Detail detail = new T_Transfer_Detail
            {
                id = Guid.NewGuid(),
                production_id = production.id,
                service_no = string.Empty,
                transfer_bill = 0,
            };
            return detail;
        }

        public override Guid GetId(T_Transfer_Detail model)
        {
            return model.id;
        }

        public override bool IsExit(string id)
        {
            return GetList().Count(p => p.production_id == GetProduction(id).id) > 0;
        }

        private T_Way_Production GetProduction(string id)
        {
            IWayProductionDal _way_production = UIHelper.Resolve<IWayProductionDal>();
            T_Way_Production production = _way_production.GetSingleByWay(id);
            return production;
        }
    }
}