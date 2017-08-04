using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxEditors;
using System.ComponentModel;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxDateEdit
    {
        private bool _defaultToday;
        /// <summary>
        /// 默认当天
        /// </summary>
        [
        Browsable(true),
        Description("默认当天"),
        Category("扩展")
        ]
        public virtual bool DefaultToday
        {
            get { return _defaultToday; }
            set { _defaultToday = value; }
        }
        private int _defaultAddDay=0;
        /// <summary>
        /// 默认当天
        /// </summary>
        [
        Browsable(true),
        Description("默认当天后几天"),
        Category("扩展")
        ]
        public virtual int DefaultAddToday
        {
            get { return _defaultAddDay; }
            set { _defaultAddDay = value; }
        }
    }
}
