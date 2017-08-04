using System.ComponentModel;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxSpinEdit
    {
        private bool _isInteger;
        /// <summary>
        /// 是否正整数
        /// </summary>
        [
        Browsable(true),
        Description("是否正整数"),
        Category("扩展")
        ]
        public virtual bool IsInteger
        {
            get { return _isInteger; }
            set { _isInteger = value; }
        }
    }
}
