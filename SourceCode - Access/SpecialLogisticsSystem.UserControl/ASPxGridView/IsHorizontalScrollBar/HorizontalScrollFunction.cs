using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxGridView;
using System.Web.UI.WebControls;
using System.Web.UI;
using DevExpress.Web.ASPxEditors;

namespace SpecialLogisticsSystem.UserControl
{
    /// <summary>
    /// 扩展功能：显示CheckBox
    /// </summary>
    public class HorizontalScrollFunction
    {
        public static void _sgv_HorizontalScroll(ASPxGridView _sgv, EventArgs e)
        {
            // _sgv.Settings.ShowHorizontalScrollBar = (ScrollBarMode)Enum.Parse(typeof(ScrollBarMode), HorzScrollCombo.Text);
            //_sgv.Settings.ShowHorizontalScrollBar
        }
    }
}
