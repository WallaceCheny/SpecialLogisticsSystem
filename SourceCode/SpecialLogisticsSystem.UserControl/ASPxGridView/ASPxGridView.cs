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
    public partial class ASPxGridView : DevExpress.Web.ASPxGridView.ASPxGridView
    {

        public ASPxGridView()
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

        //protected override void RaiseHtmlEditFormCreated(WebControl container)
        //{
        //    base.RaiseHtmlEditFormCreated(container);
        //}

        //protected override void RaiseRowUpdating(DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        //{
        //    base.RaiseRowUpdating(e);
        //}

        //protected override void RaiseRowInserting(DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        //{
        //    base.RaiseRowInserting(e);
        //}

        //protected override void RaiseRowDeleting(DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        //{
        //    base.RaiseRowDeleting(e);
        //}

        private GridViewEditingMode _editingMode = GridViewEditingMode.PopupEditForm;
        /// <summary>
        /// 是否是弹出
        /// </summary>
        [
        Browsable(true),
        Description("弹出"),
        Category("扩展")
        ]
        public virtual GridViewEditingMode EditingMode
        {
            get { return _editingMode; }
            set { _editingMode = value; }
        }

        private bool _isAddNew = false;
        /// <summary>
        /// 是否开始编辑
        /// </summary>
        [
        Browsable(true),
        Description("是否开始编辑"),
        Category("扩展")
        ]
        public virtual bool IsAddNew
        {
            get { return _isAddNew; }
            set { _isAddNew = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            ////<Settings GridLines="Both" ShowVerticalScrollBar="true" />
            //// <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" AllowSelectByRowClick="true"
            //// AllowSort="true" />
            ////<SettingsText CommandUpdate="保存" CommandCancel="取消" EmptyDataRow="无数据" />
            ////<SettingsEditing Mode="PopupEditForm" PopupEditFormVerticalAlign="WindowCenter"
            ////             PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormVerticalOffset="-75"
            ////             PopupEditFormHorizontalOffset="-85" />
            //// <SettingsPager PageSize="20" Summary-Text="第{0}/{1}页(共{2}条)" />
            //导致export 操作异常
            this.SettingsBehavior.AllowSelectByRowClick = true;
            this.SettingsBehavior.AllowFocusedRow = true;
            //this.KeyFieldName = "id";
            this.SettingsText.EmptyDataRow = ConstantsHelper.Empty_Data;
            this.Settings.GridLines = GridLines.Both;
            this.Settings.ShowVerticalScrollBar = true;
            this.AutoGenerateColumns = false;
            this.Width = Unit.Percentage(100);
            this.ClientInstanceName = this.ID;
            //if (IsPopup)
            //{
            this.SettingsEditing.Mode = EditingMode;
            //}
            //else
            //{
            //    this.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow;
            //}
            this.SettingsEditing.PopupEditFormVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter;
            this.SettingsEditing.PopupEditFormHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.Center;
            if (this.RowCheckBox || this.RowRadio)
            {
                RowCheckBoxFunction._sgv_RowCheckBox(this, e);
                if (this.RowRadio)
                {
                    RowRadioFunction._sgv_RowRadio(this, e);
                }
            }
            //if (this.RowIndex)
            //{
            //    GridViewDataTextColumn textColumn = new GridViewDataTextColumn();
            //    textColumn.Width = Unit.Pixel(40);
            //    textColumn.Caption = "序号";
            //    textColumn.FixedStyle = GridViewColumnFixedStyle.Left;
            //    textColumn.VisibleIndex = 1;
            //    this.Columns.Add(textColumn);
            //}
            if (this.IsPage)
            {
                CommonSetting.SetPager(this.SettingsPager, this.PageSize);
            }
            if (this.IsAddNew)
            {
                this.AddNewRow();
            }
            base.OnInit(e);
        }

        //protected override void RaiseHtmlRowCreated(DevExpress.Web.ASPxGridView.Rendering.GridViewTableRow row)
        //{
        //    if (this.RowIndex)
        //    {
        //        RowIndexFunction._sgv_RowIndex(this, row);
        //    }
        //    base.RaiseHtmlRowCreated(row);
        //}
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
