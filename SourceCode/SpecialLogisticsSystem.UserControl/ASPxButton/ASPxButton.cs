using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace SpecialLogisticsSystem.UserControl
{
    public partial class ASPxButton : DevExpress.Web.ASPxEditors.ASPxButton
    {
        private bool _isSearch;
        /// <summary>
        /// 是否查询按钮
        /// </summary>
        [
        Browsable(true),
        Description("是否查询按钮"),
        Category("扩展")
        ]
        public virtual bool IsSearch
        {
            get { return _isSearch; }
            set { _isSearch = value; }
        }
        private bool _isInitSearch=true;
        /// <summary>
        /// 是否初始化查询按钮
        /// </summary>
        [
        Browsable(true),
        Description("是否初始化查询按钮"),
        Category("扩展")
        ]
        public virtual bool IsInitSearch
        {
            get { return _isInitSearch; }
            set { _isInitSearch = value; }
        }
        private string _jsSearch;
        /// <summary>
        /// Search Js
        /// </summary>
        [
        Browsable(true),
        Description("查询按钮Js"),
        Category("扩展")
        ]
        public virtual string JsSearch
        {
            get { return _jsSearch; }
            set { _jsSearch = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            this.ClientInstanceName = this.ID;
            if (IsSearch)
            {
                //<cx:ASPxButton ID="btnSearch" runat="server"  CssClass="search" Text="查询" AutoPostBack="False">
                //    <Image Url="/Scripts/themes/icons/search.png" Width="16px" Height="16px" />
                //    <ClientSideEvents Click="function() { viewSetting.Search(filterCondition()); }" />
                //</cx:ASPxButton>
                this.Text = "查询";
                this.AutoPostBack = false;
                this.CssClass = "mainSearch";
                this.Image.Url = "/Scripts/themes/icons/search.png";
                this.Image.Width = Unit.Pixel(16);
                this.Image.Height = Unit.Pixel(16);
                this.ClientSideEvents.Click = JsSearch;
                if (IsInitSearch) this.ClientSideEvents.Init = JsSearch;
            }
            base.OnInit(e);
        }
    }
}
