using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.UserControl;
using DevExpress.Web.ASPxEditors;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class ComoboxCode : BaseUserControl
    {
        public string ClientSideJs
        {
            set
            {
                this.cmbCode.ClientSideEvents.ValueChanged = value;
            }
        }

        public int Width
        {
            set
            {
                this.cmbCode.Width = Unit.Pixel(value);
            }
        }
        public CodeType codeType
        {
            get;
            set;
        }
        /// <summary>
        /// 设置默认值
        /// </summary>
        public string DefaultValue
        {
            get;
            set;
        }
        public bool IsSubRequired
        {
            set
            {
                CommonSetting.SetRequired(cmbCode.ValidationSettings, true);
            }
        }
        public bool IsRequired
        {
            set
            {
                CommonSetting.SetRequired(cmbCode.ValidationSettings, false);
            }
        }

        public string Index
        {
            get
            {
                return ConvertHelper.ObjectToString(ViewState["Index"]);
            }
            set
            {
                ViewState["Index"] = value;
            }
        }

        public void SetValue(string strCode)
        {
            var defaultItem = cmbCode.Items.FindByValue(strCode);
            if (defaultItem != null) defaultItem.Selected = true;
        }
        public string GetValue()
        {
            return ConvertHelper.ObjectToString(cmbCode.Value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cmbCode.ID = cmbCode.ID + Index;
            cmbCode.ClientInstanceName = cmbCode.ClientInstanceName + Index;
            QueryInfo<T_Cm_Code> queryInfo = new QueryInfo<T_Cm_Code>();
            queryInfo.SetQuery("para_type", codeType.ToString());
            if (!string.IsNullOrEmpty(DefaultValue))
            {
                DataBindDropDownList.DataBindCode(cmbCode, queryInfo, DefaultValue);
            }
            else
            {
                DataBindDropDownList.DataBindCode(cmbCode, queryInfo);
            }
            cmbCode.Items.Insert(0,new ListEditItem("--请选择--"));
        }
    }
}