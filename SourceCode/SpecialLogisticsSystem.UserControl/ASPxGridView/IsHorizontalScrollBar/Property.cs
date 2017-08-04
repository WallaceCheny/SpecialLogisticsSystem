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
        private bool _isHorizontal;
        /// <summary>
        /// 水平滚动条
        /// </summary>
        [
        Browsable(true),
        Description("复选"),
        Category("扩展")
        ]
        public virtual bool IsHorizontal
        {
            get { return _isHorizontal; }
            set { _isHorizontal = value; }
        }
    }
}
