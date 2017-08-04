using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.UserControl
{
    public class RequiredFunction
    {
        public static void _txt_Required(ASPxTextBox _txt)
        {
            CommonSetting.SetRequired(_txt.ValidationSettings, _txt.IsSubRequired);
        }
    }
}
