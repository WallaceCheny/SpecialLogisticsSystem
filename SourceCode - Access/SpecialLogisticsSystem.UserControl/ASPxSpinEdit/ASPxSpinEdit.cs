using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxSpinEdit : DevExpress.Web.ASPxEditors.ASPxSpinEdit
    {
        private bool _isPrice;
        /// <summary>
        /// 是否是金额
        /// </summary>
        [
        Browsable(true),
        Description("是否正整数"),
        Category("扩展")
        ]
        public virtual bool IsPrice
        {
            get { return _isPrice; }
            set { _isPrice = value; }
        }
        private bool _isSubRequired;
        /// <summary>
        /// 子GridView中是否必填
        /// </summary>
        [
        Browsable(true),
        Description("是否正整数"),
        Category("扩展")
        ]
        public virtual bool IsSubRequired
        {
            get { return _isSubRequired; }
            set { _isSubRequired = value; }
        }
        protected override void OnInit(EventArgs e)
        {
            if (IsInteger)
            {
                NumberTypeFunction._spin_Price(this);
            }
            if (IsPrice)
            {
                this.DecimalPlaces = 2;
                this.DisplayFormatString = "{0:C}";
            }
            if (IsSubRequired)
            {
                CommonSetting.SetRequired(this.ValidationSettings, true);
            }
            this.ClientInstanceName = this.ID;
            base.OnInit(e);
        }
    }
}
