using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxGridView;
using System.ComponentModel;
using SpecialLogisticsSystem.Tool;
using DevExpress.Web.ASPxEditors;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class CustomGrid : ASPxGridView
    {

        public CustomGrid()
        {
            //EventArgs e = new EventArgs();
         
        }

        private static readonly object rowDataBoundDataRowEventKey = new object();
        /// <summary>
        /// RowDataBoundDataRow事件委托
        /// </summary>
        /// <remarks>
        /// RowDataBound事件中的DataControlRowType.DataRow部分
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void RowDataBoundDataRowHandler(object sender, ASPxGridViewEditFormEventArgs e);

        /// <summary>
        /// RowDataBound事件中的DataControlRowType.DataRow部分
        /// </summary>
        [Category("扩展")]
        public event RowDataBoundDataRowHandler RowDataBoundDataRow
        {
            add { Events.AddHandler(rowDataBoundDataRowEventKey, value); }
            remove { Events.RemoveHandler(rowDataBoundDataRowEventKey, value); }
        }

        /// <summary>
        /// 触发RowDataBoundDataRow事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRowDataBoundDataRow(ASPxGridViewEditFormEventArgs e)
        {
            RowDataBoundDataRowHandler handler = Events[rowDataBoundDataRowEventKey] as RowDataBoundDataRowHandler;

            if (handler != null)
            {
                handler(this, e);
            }
        }


        protected override void OnInit(EventArgs e)
        {
            this.SettingsBehavior.AllowSelectByRowClick = true;
            this.SettingsBehavior.AllowFocusedRow = true;
            this.SettingsText.EmptyDataRow = "无数据";
            this.Settings.GridLines = GridLines.Both;
            this.Settings.ShowVerticalScrollBar = true;
            if (this.RowCheckBox || this.RowRadio)
            {
                RowCheckBoxFunction._sgv_RowCheckBox(this, e);
                if (this.RowRadio)
                {
                    RowRadioFunction._sgv_RowRadio(this, e);
                }
            }
          
            base.OnInit(e);
        }


        protected override void RaiseHtmlRowCreated(DevExpress.Web.ASPxGridView.Rendering.GridViewTableRow row)
        {
            if (this.RowIndex)
            {
                RowIndexFunction._sgv_RowIndex(this, row);
            }
            base.RaiseHtmlRowCreated(row);
        }
        ///// <summary>
        ///// OnRowDataBound
        ///// </summary>
        ///// <param name="e">e</param>
        //protected override string OnCallbackException(Exception e)
        //{
        //    LogHelper.WriteLog(string.Empty, e);
        //    return base.OnCallbackException(e);
        //}


    }
}
