using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.Model
{
    public interface ICodeName
    {
        string GetCodeName(CodeType codeType, string para_value);
        string GetConfigValue(ConfigType configType);
        bool GetConfigResult(ConfigType configType);
        dynamic GetProduction(Guid productionId);
        T_Cm_Link GetLink(Guid linkID);
    }

    public class CodeName
    {
        public static CodeName Instance = new CodeName();
        public ICodeName iCodeName { get; private set; }

        public void Initialize(ICodeName codeName)
        {
            iCodeName = codeName;
        }
    }
}
