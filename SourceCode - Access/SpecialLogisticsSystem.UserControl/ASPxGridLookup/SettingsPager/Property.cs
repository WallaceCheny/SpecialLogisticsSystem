using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxGridLookup
    {
        private int _pageSize = 20;
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
        //private string _newJs;
        ///// <summary>
        ///// 新建按钮Client,Js
        ///// </summary>
        //[
        //Browsable(true),
        //Description("新建按钮"),
        //Category("扩展")
        //]
        //public virtual string NewJs
        //{
        //    get { return _newJs; }
        //    set { _newJs = value; }
        //}
        //private string _newUrl;
        ///// <summary>
        ///// 新建地址
        ///// </summary>
        //[
        //Browsable(true),
        //Description("新建地址"),
        //Category("扩展")
        //]
        //public virtual string NewUrl
        //{
        //    get { return _newUrl; }
        //    set { _newUrl = value; }
        //}
        //private string _cancelJs;
        ///// <summary>
        ///// 取消按钮Client,Js
        ///// </summary>
        //[
        //Browsable(true),
        //Description("取消按钮"),
        //Category("扩展")
        //]
        //public virtual string CancelJs
        //{
        //    get { return _cancelJs; }
        //    set { _cancelJs = value; }
        //}
    }
}
