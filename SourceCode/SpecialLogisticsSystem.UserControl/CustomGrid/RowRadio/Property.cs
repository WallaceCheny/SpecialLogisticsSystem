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
    public partial class CustomGrid
    {
        private bool _rowRadio;
        /// <summary>
        /// 单选
        /// </summary>
        [
        Browsable(true),
        Description("单选"),
        Category("扩展")
        ]
        public virtual bool RowRadio
        {
            get { return _rowRadio; }
            set { _rowRadio = value; }
        }

        /// <summary>
        /// 单选框值
        /// </summary>
        [
            Browsable(false),
        ]
        public string Radioeditem
        {
            get { return ViewState["Radioeditem"] != null ? (string)ViewState["Radioeditem"] : null; }
            set { ViewState["Radioeditem"] = value; }
        }

        //public void GetRadioedItem()
        //{
        //    if (this.DataKeyNames.Length < 1) return;
        //    string selecteditems = null;
        //    if (this.RowCheckeditems == null)
        //    {
        //        selecteditems = "";
        //    }
        //    else
        //    {
        //        selecteditems = this.Radioeditem;
        //    }
        //    for (int i = 0; i < this.Rows.Count; i++)
        //    {
        //        RadioButton radio = (RadioButton)this.Rows[i].FindControl("ItemRadio");
        //        string id = this.DataKeys[i].Values[0].ToString();

        //        if (radio.Checked)
        //        {
        //            selecteditems = id;
        //        }
        //    }

        //    this.Radioeditem = selecteditems;
        //}

        //public void SetRowRadioedItem(GridViewRowEventArgs e)
        //{
        //    if (this.DataKeyNames.Length < 1 || !this.IsRememberState) return;
        //    if (e.Row.RowIndex > -1 && this.Radioeditem != null && this.Radioeditem != "")
        //    {
        //        RadioButton radio = (RadioButton)e.Row.FindControl("ItemRadio");
        //        string id = this.DataKeys[e.Row.RowIndex].Values[0].ToString();
        //        if (Radioeditem == id)
        //            radio.Checked = true;
        //        else
        //            radio.Checked = false;
        //    }
        //}
    }
}
