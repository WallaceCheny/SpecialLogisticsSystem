using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class EnumProvider
    {
        public List<IDNameDescription> GetWayStatueData()
        {
           return ConvertHelper.EnumnToNameDescription(typeof(WayStatue));
        }

        public List<IDNameDescription> GetStowageStatueData()
        {
            return ConvertHelper.EnumnToNameDescription(typeof(StowageStatue));
        }

        public List<T_Cm_Code> GetPackTypeData()
        {
            QueryInfo<T_Cm_Code> codeList = new QueryInfo<T_Cm_Code>();
            codeList.SetQuery(T_Cm_Code.TypeColumnName, CodeType.wrap_type.ToString());
            return UIHelper.Resolve<ICmCodeDal>().GetList(codeList).ToList();
        }

        public List<T_Cm_Code> GetChargeModeData()
        {
            QueryInfo<T_Cm_Code> codeList = new QueryInfo<T_Cm_Code>();
            codeList.SetQuery(T_Cm_Code.TypeColumnName, CodeType.price_type.ToString());
            return UIHelper.Resolve<ICmCodeDal>().GetList(codeList).ToList();
        }
    }
}