using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.UserControl;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class Area : BaseUserControl
    {
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
        public bool IsRequired
        {
            set
            {
                if (value)
                {
                    CommonSetting.SetRequired(ddlDistrict.ValidationSettings, false);
                }
            }
        }

        public bool IsSubRequired
        {
            set
            {
                CommonSetting.SetRequired(ddlDistrict.ValidationSettings, true);
            }
        }

        public long ProvinceID
        {
            get
            {
                return ConvertHelper.ObjectToLong(ddlProvince.Value);
            }
            set
            {
                DataBindDropDownList.DataBindProvince(ddlProvince, value.ToString());
            }
        }

        public long CityID
        {
            get
            {
                return ConvertHelper.ObjectToLong(ddlCity.Value);
            }
            set
            {
                DataBindDropDownList.DataBindCity(ddlCity, ddlProvince.Value, value.ToString());
            }
        }

        public long DistrictID
        {
            get
            {
                return ConvertHelper.ObjectToLong(ddlDistrict.Value);
            }
            set
            {
                DataBindDropDownList.DataBindDistrict(ddlDistrict, ddlCity.Value, value.ToString());
            }
        }
        /// <summary>
        /// 显示如：福建 - 南平 -延平
        /// </summary>
        public string GetAreaName
        {
            get
            {
               return ddlProvince.Text + "-" + ddlCity.Text + "-" + ddlDistrict.Text;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlProvince.ID = ddlProvince.ID + Index;
            ddlCity.ID = ddlCity.ID + Index;
            ddlDistrict.ID = ddlDistrict.ID + Index;
            DataBindDropDownList.DataBindProvince(ddlProvince);
        }

        protected void ddlDistrict_Callback(object sender, CallbackEventArgsBase e)
        {
            DataBindDropDownList.DataBindDistrict(ddlDistrict, ddlCity.Value);
        }

        protected void ddlCity_Callback(object sender, CallbackEventArgsBase e)
        {
            DataBindDropDownList.DataBindCity(ddlCity, ddlProvince.Value);
        }
    }
}