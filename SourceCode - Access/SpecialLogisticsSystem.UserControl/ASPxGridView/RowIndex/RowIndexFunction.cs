using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxGridView;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using DevExpress.Web.ASPxGridView.Rendering;

namespace SpecialLogisticsSystem.UserControl
{
    public class RowIndexFunction
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RowIndexFunction()
        {

        }

        public static void _sgv_RowIndex(ASPxGridView _sgv, GridViewTableRow row)
        {
            TableCell cell = new TableCell();
            Label lab = new Label();
            int i = (_sgv.SettingsPager.PageSize * _sgv.PageIndex) + row.VisibleIndex + 1;
            lab.Text = i.ToString();
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Controls.Add(lab);
            row.Cells.AddAt(0, cell);
        }

        public class IndexTemplate : ITemplate
        {
            private GridViewTableRow _row;
            ASPxGridView _sgv;
            public IndexTemplate(GridViewTableRow row, ASPxGridView sgv)
            {
                _row = row;
                _sgv = sgv;
            }

            public void InstantiateIn(Control container)
            {
                Label lblIndex = new Label();
                int i = (_sgv.SettingsPager.PageSize * _sgv.PageIndex) + _row.VisibleIndex + 1;
                lblIndex.Text = i.ToString();
                container.Controls.Add(lblIndex);
            }
        }
    }
}
