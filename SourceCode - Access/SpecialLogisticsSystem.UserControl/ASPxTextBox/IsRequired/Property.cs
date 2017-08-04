using System.ComponentModel;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxTextBox
    {
        private bool _isRequired;
        /// <summary>
        /// 是否必填
        /// </summary>
        [
        Browsable(true),
        Description("是否必填"),
        Category("扩展")
        ]
        public virtual bool IsRequired
        {
            get { return _isRequired; }
            set { _isRequired = value; }
        }
        private bool _isSubRequired;
        /// <summary>
        /// 是否子GridView控件必填
        /// </summary>
        [
        Browsable(true),
        Description("是否必填"),
        Category("扩展")
        ]
        public virtual bool IsSubRequired
        {
            get { return _isSubRequired; }
            set { _isSubRequired = value; }
        }
    }
}
