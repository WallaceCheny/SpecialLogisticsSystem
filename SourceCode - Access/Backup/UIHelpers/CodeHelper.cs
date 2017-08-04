using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Dal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal
{
    public class CodeHelper : ICodeName
    {
        public string GetCodeName(CodeType codeType, string para_value)
        {
            string strName = string.Empty;
            CmCodeDal _code = UIHelper.Resolve<CmCodeDal>();
            QueryInfo<T_Cm_Code> queryInfo = new QueryInfo<T_Cm_Code>();
            queryInfo.SetQuery(T_Cm_Code.TypeColumnName, codeType.ToString());
            queryInfo.SetQuery(T_Cm_Code.ValueColumnName, para_value);
            T_Cm_Code code = _code.GetList(queryInfo).FirstOrDefault();
            if (null != code)
            {
                strName = code.para_name;
            }
            return strName;
        }

        public string GetConfigValue(ConfigType configType)
        {
            CmConfigDal _config = UIHelper.Resolve<CmConfigDal>();
            QueryInfo<T_Cm_Config> queryInfo = new QueryInfo<T_Cm_Config>();
            queryInfo.SetQuery("parameter_name", configType.ToString());
            T_Cm_Config config = _config.GetList(queryInfo).FirstOrDefault();
            return config == null ? string.Empty : config.parameter_value;
        }

        public bool GetConfigResult(ConfigType configType)
        {
            return ConvertHelper.ObjectToBool(GetConfigValue(configType));
        }

        public dynamic GetProduction(Guid productionId)
        {
            QueryInfo<T_Way_Production> queryInfo = new QueryInfo<T_Way_Production>();
            queryInfo.SetQuery("id", productionId);
            queryInfo.SetXml("SelectView");
            IWayProductionDal _production = UIHelper.Resolve<IWayProductionDal>();
            IList<dynamic> results = _production.Select(queryInfo);
            return results.FirstOrDefault();
        }


        public T_Cm_Link GetLink(Guid linkID)
        {
            ICmLinkDal _link = UIHelper.Resolve<ICmLinkDal>();
            return _link.GetSingle(linkID);
        }
    }
}