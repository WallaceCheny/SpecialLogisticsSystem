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
        private bool _rowIndex;
        /// <summary>
        /// 序号
        /// </summary>
        [
        Browsable(true),
        Description("序号"),
        Category("扩展")
        ]
        public virtual bool RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }
    }
}
