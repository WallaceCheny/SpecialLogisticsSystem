using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxGridView;
using System.Web.UI;

namespace SpecialLogisticsSystemControls.GridView
{
    /// <summary>
    /// SmartGridView类，继承自GridView
    /// </summary>
    [ToolboxData(@"<{0}:LogisticsGridView runat='server'></{0}:LogisticsGridView>")]
    public partial class LogisticsGridView : ASPxGridView
    {
          /// <summary>
        /// 构造函数
        /// </summary>
        public LogisticsGridView()
        {

        }
    }
}
