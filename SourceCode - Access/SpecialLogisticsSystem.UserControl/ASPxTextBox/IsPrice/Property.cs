using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxTextBox
    {
        private bool _isPrice;
        /// <summary>
        /// 是否金额类型
        /// </summary>
        [
        Browsable(true),
        Description("是否金额类型"),
        Category("扩展")
        ]
        public virtual bool IsPrice
        {
            get { return _isPrice; }
            set { _isPrice = value; }
        }
    }
}
