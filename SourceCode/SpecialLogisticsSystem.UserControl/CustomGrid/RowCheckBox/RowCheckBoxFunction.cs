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
    public class RowCheckBoxFunction
    {
        public static void _sgv_RowCheckBox(ASPxGridView _sgv,EventArgs e)
        {
            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.ShowSelectCheckbox = true;
            commandColumn.VisibleIndex = 0;
            commandColumn.Width = Unit.Pixel(28);
            commandColumn.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
            commandColumn.HeaderTemplate = new HeaderTemplate();
            _sgv.Columns.Add(commandColumn);
        }
    }

    public class HeaderTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            ASPxCheckBox chooseAll = new ASPxCheckBox();
            chooseAll.ID = "chooseAll";
            chooseAll.Style.Value = "padding: 0px; height: 15px;";
            chooseAll.ClientSideEvents.CheckedChanged = "viewSetting.checkBox_CheckedChanged";
            container.Controls.Add(chooseAll);
        }
    }
}
