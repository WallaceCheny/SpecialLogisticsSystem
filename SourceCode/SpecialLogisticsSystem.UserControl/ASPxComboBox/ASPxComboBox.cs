using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxComboBox : DevExpress.Web.ASPxEditors.ASPxComboBox
    {
        private bool _isSetDefault;
        /// <summary>
        /// 默认 - 请选择
        /// </summary>
        [
        Browsable(true),
        Description("请选择"),
        Category("扩展")
        ]
        public virtual bool IsSetDefault
        {
            get { return _isSetDefault; }
            set { _isSetDefault = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (this.IsSetDefault)
            {
                this.ClientSideEvents.BeginCallback = "function(s, e) {s.InsertItem(0, '请选择', '');s.SetSelectedIndex(0);}";
            }
            base.OnInit(e);
        }
    }
}
