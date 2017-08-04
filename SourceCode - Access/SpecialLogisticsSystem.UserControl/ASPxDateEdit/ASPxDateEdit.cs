using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxEditors;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxDateEdit : DevExpress.Web.ASPxEditors.ASPxDateEdit
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
        /// 是否子ASPxDateEdit控件必填
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

        protected override void OnInit(EventArgs e)
        {
            this.CalendarProperties.TodayButtonText = "今天";
            this.CalendarProperties.ClearButtonText = "清除";
            this.CalendarProperties.FastNavProperties.CancelButtonText = "取消";
            this.CalendarProperties.FastNavProperties.OkButtonText = "确定";
            if (DefaultToday)
            {
                //this.Value =ConvertHelper.ObjectToStandardDate(DateTime.Now);
                this.Date = DateTime.Now;
            }
            if (DefaultAddToday > 0)
            {
                this.Date = DateTime.Now.AddDays(DefaultAddToday);
            }
            if (this.IsRequired || this.IsSubRequired)
            {
                CommonSetting.SetRequired(this.ValidationSettings, this.IsSubRequired);
            }
            base.OnInit(e);
        }
    }
}
