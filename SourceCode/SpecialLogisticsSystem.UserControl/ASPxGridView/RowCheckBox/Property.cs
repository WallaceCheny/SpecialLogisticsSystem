using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SpecialLogisticsSystem.UserControl
{
    /// <summary>
    /// SmartGridView类的属性部分
    /// </summary>
    public partial class ASPxGridView
    {
        private bool _rowCheckBox;
        /// <summary>
        /// 复选
        /// </summary>
        [
        Browsable(true),
        Description("复选"),
        Category("扩展")
        ]
        public virtual bool RowCheckBox
        {
            get { return _rowCheckBox; }
            set { _rowCheckBox = value; }
        }

        /// <summary>
        /// 记住选择状态
        /// </summary>
        [
        Browsable(true),
        Description("记住选中状态"),
        Category("扩展")
        ]
        public virtual bool IsRememberState
        {
            get { return ViewState["IsRememberState"] != null ? (bool)ViewState["IsRememberState"] : false; }
            set { ViewState["IsRememberState"] = value; }
        }


        /// <summary>
        /// 复选框值
        /// </summary>
        [
            Browsable(false),
        ]
        public List<string> RowCheckeditems
        {
            get { return ViewState["RowCheckeditems"] != null ? (List<string>)ViewState["RowCheckeditems"] : null; }
            set { ViewState["RowCheckeditems"] = value; }
        }

        //public void GetRowCheckedItem()
        //{
        //    if (this.DataKeyNames.Length < 1) return;
        //    List<string> selecteditems = null;
        //    if (this.RowCheckeditems == null)
        //    {
        //        selecteditems = new List<string>();
        //    }
        //    else
        //    {
        //        if (IsRememberState)
        //        {
        //            selecteditems = this.RowCheckeditems;
        //        }
        //        else
        //        {
        //            selecteditems = new List<string>();
        //        }
        //    }
        //    for (int i = 0; i < this.Rows.Count; i++)
        //    {
        //        CheckBox cbx = (CheckBox)this.Rows[i].FindControl("ItemCheckBox");
        //        string id = this.DataKeys[i].Values[0].ToString();

        //        if (selecteditems.Contains(id) && !cbx.Checked)
        //            selecteditems.Remove(id);
        //        if (!selecteditems.Contains(id) && cbx.Checked)
        //            selecteditems.Add(id);
        //    }
        //    this.RowCheckeditems = selecteditems;
        //}

        //public void SetRowCheckedItem(GridViewRowEventArgs e)
        //{
        //    if (this.DataKeyNames.Length < 1 || !this.IsRememberState) return;
        //    if (e.Row.RowIndex > -1 && this.RowCheckeditems != null)
        //    {
        //        CheckBox cbx = (CheckBox)e.Row.FindControl("ItemCheckBox");
        //        string id = this.DataKeys[e.Row.RowIndex].Values[0].ToString();
        //        if (RowCheckeditems.Contains(id))
        //            cbx.Checked = true;
        //        else
        //            cbx.Checked = false;
        //    }
        //}
    }
}
