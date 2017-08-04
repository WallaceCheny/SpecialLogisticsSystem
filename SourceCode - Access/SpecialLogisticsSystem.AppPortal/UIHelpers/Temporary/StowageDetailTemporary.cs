using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class StowageDetailTemporary : BaseTemporary<T_Stowage_Detail>
    {
        public override string SessionName
        {
            get { return Constants.StowageDetail; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">wayID</param>
        /// <returns></returns>
        public override T_Stowage_Detail GetMode(string id)
        {
            IWayProductionDal _way_production = UIHelper.Resolve<IWayProductionDal>();
            T_Way_Production production = _way_production.GetSingleByWay(id);
            IStowageDetailDal _stowage_detail = UIHelper.Resolve<IStowageDetailDal>();
            QueryInfo<T_Stowage_Detail> queryInfo = new QueryInfo<T_Stowage_Detail>().SetQuery(T_Stowage_Detail.ProudctionIdColumnName, production.id);
            T_Stowage_Detail detail = _stowage_detail.GetList(queryInfo).FirstOrDefault();
            if (detail == null)
            {
                detail = new T_Stowage_Detail
                {
                    id = Guid.NewGuid(),
                    bill_id = production.bill_id,
                    production_id = production.id,
                    production_number = production.production_number,
                };
            }
            return detail;
        }

        public override Guid GetId(T_Stowage_Detail model)
        {
            return model.id;
        }

        public override bool IsExit(string id)
        {
            return GetList().Count(p => p.bill_id ==ConvertHelper.ObjectToGuid(id)) > 0;
        }
    }
}