using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class CustomLookUp
    {
        private bool _isNew=true;
        /// <summary>
        /// 是否需要
        /// </summary>
        [
        Browsable(true),
        Description("是否需要新建按钮"),
        Category("扩展")
        ]
        public virtual bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        private string _newJs;
        /// <summary>
        /// 新建按钮Client,Js
        /// </summary>
        [
        Browsable(true),
        Description("新建按钮"),
        Category("扩展")
        ]
        public virtual string NewJs
        {
            get { return _newJs; }
            set { _newJs = value; }
        }
        private string _newUrl;
        /// <summary>
        /// 新建地址
        /// </summary>
        [
        Browsable(true),
        Description("新建地址"),
        Category("扩展")
        ]
        public virtual string NewUrl
        {
            get { return _newUrl; }
            set { _newUrl = value; }
        }
        private string _cancelJs;
        /// <summary>
        /// 取消按钮Client,Js
        /// </summary>
        [
        Browsable(true),
        Description("取消按钮"),
        Category("扩展")
        ]
        public virtual string CancelJs
        {
            get { return _cancelJs; }
            set { _cancelJs = value; }
        }
    }
}
