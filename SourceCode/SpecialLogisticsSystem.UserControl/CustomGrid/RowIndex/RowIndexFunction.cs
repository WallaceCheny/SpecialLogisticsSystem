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
            GridViewDataTextColumn textColumn = new GridViewDataTextColumn();
            textColumn.Width = Unit.Pixel(20);
            textColumn.ToolTip = "序号";
            textColumn.VisibleIndex = 1;
            textColumn.DataItemTemplate = new IndexTemplate(row);
            _sgv.Columns.Add(textColumn);
        }

        public class IndexTemplate : ITemplate
        {
            private GridViewTableRow _row;
            public IndexTemplate(GridViewTableRow row)
            {
                _row = row;
            }

            public void InstantiateIn(Control container)
            {
                Label lblIndex =new  Label();
                lblIndex.Text = _row.VisibleIndex.ToString();
                container.Controls.Add(lblIndex);
            }
        }
    }
}
