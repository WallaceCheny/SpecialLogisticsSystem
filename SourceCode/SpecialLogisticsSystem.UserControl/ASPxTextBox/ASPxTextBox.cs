using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxTextBox : DevExpress.Web.ASPxEditors.ASPxTextBox
    {
        private int? _width;
        /// <summary>
        /// 宽度-像素
        /// </summary>
        [
        Browsable(true),
        Description("宽度-像素"),
        Category("扩展")
        ]
        public virtual int? WidthPixel
        {
            get { return _width; }
            set { _width = value; }
        }

        private bool _isReadOnly;
        /// <summary>
        /// 是否只读
        /// </summary>
        [
        Browsable(true),
        Description("是否只读"),
        Category("扩展")
        ]
        public virtual bool IsReadOnly
        {
            get { return _isReadOnly; }
            set { 
                _isReadOnly = value;
                if (value)
                {
                    this.BackColor = Color.FromArgb(224, 224, 224);
                    this.ReadOnly = true;
                }
            }
        }

        private string _textChangedJS;
        /// <summary>
        /// 文字修改时候触发
        /// </summary>
        [
        Browsable(true),
        Description("文字修改时候触发"),
        Category("扩展")
        ]
        public virtual string TextChangedJS
        {
            get { return _textChangedJS; }
            set
            {
                _textChangedJS = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.ClientInstanceName = this.ID;
            //if (this.WidthPixel.HasValue)
            //{
            //    this.Width = Unit.Pixel(WidthPixel.Value);
            //}
            if (this.IsRequired || this.IsSubRequired)
            {
                RequiredFunction._txt_Required(this);
            }
            if (this.IsPrice)
            {
                PriceFunction._txt_Price(this);
            }
            if (this.IsReadOnly)
            {
                this.BackColor = Color.FromArgb(224, 224, 224);
                this.ReadOnly = true;
            }
            if (!string.IsNullOrEmpty(TextChangedJS))
            {
                this.ClientSideEvents.TextChanged = TextChangedJS;
            }
            base.OnInit(e);
        }
    }
}
