using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxGridView;

namespace SpecialLogisticsSystem.UserControl
{
    /// <summary>
    /// 扩展功能：单选
    /// </summary>
    public class RowRadioFunction
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RowRadioFunction()
        {

        }

        public static void _sgv_RowRadio(ASPxGridView _sgv, EventArgs e)
        {
            _sgv.SettingsBehavior.AllowSelectSingleRowOnly = true;
        }
    }
}
