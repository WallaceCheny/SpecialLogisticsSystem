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
        private bool _isPage = true;
        /// <summary>
        /// 是否分页
        /// </summary>
        [
        Browsable(true),
        Description("序号"),
        Category("扩展")
        ]
        public virtual bool IsPage
        {
            get { return _isPage; }
            set { _isPage = value; }
        }

        private int _pageSize = 15;
        /// <summary>
        /// 分页条数
        /// </summary>
        [
        Browsable(true),
        Description("分页条数"),
        Category("扩展")
        ]
        public virtual int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
    }
}
