using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxGridLookup;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using DevExpress.Web.ASPxEditors;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.UserControl
{
    public class CommandFunction
    {
        public static void _look_Command(ASPxGridLookup _look, EventArgs e)
        {
            _look.GridViewProperties.Templates.StatusBar = new StatusBarTemplate(_look);

        }

        public class StatusBarTemplate : ITemplate
        {
            private ASPxGridLookup _lookUp;
            public StatusBarTemplate(ASPxGridLookup lookUp)
            {
                _lookUp = lookUp;
            }
            public void InstantiateIn(Control container)
            {
                HtmlTable table = new HtmlTable();
                table.Width = "100%";
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cell1 = new HtmlTableCell();
                cell1.Width = "100%";
                ASPxButton btnRefresh = new ASPxButton();
                btnRefresh.Text = "刷新";
                btnRefresh.Width = Unit.Pixel(80);
                btnRefresh.AutoPostBack = false;
                btnRefresh.ClientSideEvents.Click = "viewSetting.lookup_Refresh";
                btnRefresh.JSProperties[ConstantsHelper.ClientInstanceName] = _lookUp.ClientInstanceName;
                cell1.Controls.Add(btnRefresh);
                HtmlTableCell cell2 = new HtmlTableCell();
                if (_lookUp.IsNew || _lookUp.IsConfirm)
                {
                    ASPxButton btnNew = new ASPxButton();
                    btnNew.Text = _lookUp.IsNew ? "编辑" : "确定";
                    btnNew.Width = Unit.Pixel(80);
                    btnNew.AutoPostBack = false;
                    btnNew.ClientSideEvents.Click = _lookUp.IsNew ? "viewSetting.lookup_New" : "viewSetting.lookup_Confirm";
                    btnNew.JSProperties[ConstantsHelper.ClientInstanceName] = _lookUp.ClientInstanceName;
                    btnNew.JSProperties["cpNewUrl"] = _lookUp.NewUrl;
                    cell2.Controls.Add(btnNew);
                }
                HtmlTableCell cell3 = new HtmlTableCell();
                ASPxButton btnCancel = new ASPxButton();
                btnCancel.Text = "清除";
                btnCancel.Width = Unit.Pixel(80);
                btnCancel.AutoPostBack = false;
                btnCancel.JSProperties[ConstantsHelper.ClientInstanceName] = _lookUp.ClientInstanceName;
                btnCancel.ClientSideEvents.Click = ConvertHelper.ReturnDefault(_lookUp.CancelJs, "viewSetting.lookup_Cancel");
                cell3.Controls.Add(btnCancel);
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                table.Rows.Add(row);
                container.Controls.Add(table);
            }
        }
    }
}
