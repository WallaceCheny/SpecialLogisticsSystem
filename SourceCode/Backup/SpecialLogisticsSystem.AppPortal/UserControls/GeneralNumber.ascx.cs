using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.UserControl;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class GeneralNumber : BaseUserControl
    {
        public CodeTable CodeEnum
        {
            get;
            set;
        }
        public int Width
        {
            set
            {
                this.number.Width = Unit.Pixel(value);
            }
        }
        public bool IsRequired
        {
            set
            {
                if (value)
                {
                    CommonSetting.SetRequired(number.ValidationSettings, false);
                }
            }
        }
        public void SetValue(string strNumber)
        {
            number.Text = strNumber;
        }
        /// <summary>
        /// 是否有运单号
        /// </summary>
        public bool HasValue
        {
            get{
                return !string.IsNullOrEmpty(number.Text);
            }
        }
        public string GetNewNumber()
        {
            if (string.IsNullOrEmpty(number.Text))
            {
                ICmSequenceNumberDal _number = UIHelper.Resolve<ICmSequenceNumberDal>();
                number.Text = _number.GetNumber(CodeEnum);
            }
            return number.Text;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}