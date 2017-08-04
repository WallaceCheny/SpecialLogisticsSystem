using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.UserControl;
using System.Web.UI.WebControls;

namespace SpecialLogisticsSystem.AppPortal
{
    public abstract class BaseLookUp : System.Web.UI.UserControl
    {
        protected abstract ASPxGridLookup _lookUp { get; }
        protected abstract void BindData();

        protected override void OnLoad(EventArgs e)
        {
            _lookUp.ID = _lookUp.ID + Index;
            _lookUp.ClientInstanceName = _lookUp.ClientInstanceName + Index;
            BindData();
            base.OnLoad(e);
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
        public int Width
        {
            set
            {
                this._lookUp.Width = Unit.Pixel(value);
            }
        }
        /// <summary>
        /// 是否需要新建按钮
        /// </summary>
        public bool IsNew
        {
            set
            {
                this._lookUp.IsNew = value;
            }
        }
        public string TextFormatString
        {
            set
            {
                _lookUp.TextFormatString = value;
            }
        }
        public void SetValue(Guid? editValue)
        {
            this._lookUp.Value = editValue;
        }

        public virtual Guid? GetValue()
        {
            List<object> dataList = _lookUp.DataSource as List<object>;
            if (dataList==null || dataList.Count == 0) return null;
            return ConvertHelper.ObjectToGuid(_lookUp.Value);
        }
        public string ValidatetionGroupName { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsRequrided
        {
            set
            {
                if (value)
                {
                    CommonSetting.SetRequired(this._lookUp.ValidationSettings,false);
                }
            }
        }

    }
}