using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.UserControl;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class CityLookUp : BaseLookUp
    {
        public bool IsRequired
        {
            set
            {
                if (value)
                {
                    CommonSetting.SetRequired(city_customelookup.ValidationSettings, false);
                }
            }
        }
        public int Width
        {
            set
            {
                this.city_customelookup.Width = Unit.Pixel(value);
            }
        }

        public bool IsSubRequired
        {
            set
            {
                CommonSetting.SetRequired(city_customelookup.ValidationSettings, true);
            }
        }

        /// <summary>
        /// 是否设置默认值
        /// </summary>
        public bool IsDefault
        {
            get;
            set;
        }

        /// <summary>
        /// 是否是起始站
        /// </summary>
        public bool IsStartCity
        {
            get;
            set;
        }

        /// <summary>
        /// 是否是目的的
        /// </summary>
        public bool IsEndCity
        {
            get;
            set;
        }

        public string GetCityValue()
        {
            return ConvertHelper.ObjectToString(city_customelookup.Value);
        }

        public void SetCityValue(string editValue)
        {
            if (this.city_customelookup.DataSource == null)
            {
                BindData();
            }
            var cityList= this.city_customelookup.DataSource as List<IDNameDescription>;
            if (string.IsNullOrEmpty(editValue)) return;
            var city=cityList.FirstOrDefault(p=>p.Name.Contains(editValue));
            if(null!=city)
            {
                this.city_customelookup.Value = city.Name;
            }
            else
            {
                this.city_customelookup.Value = editValue;
            }
        }

        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return this.city_customelookup; }
        }

        private string CombineCity(string cityName, string districtName)
        {
            string newCityName = districtName;
            if (!districtName.Contains("市"))
            {
                newCityName = cityName + "-" + districtName;
            }
            return newCityName;
        }

        protected override void BindData()
        {
            if (this.city_customelookup.DataSource != null) return;
            List<IDNameDescription> citynameList = new List<IDNameDescription>();

            QueryInfo<T_Cm_City> queryInfo2 = new QueryInfo<T_Cm_City>();
            ICmCityDal _city = UIHelper.Resolve<ICmCityDal>();
            List<T_Cm_City> cityList = _city.GetList(queryInfo2).ToList();
            foreach (var item in cityList)
            {
                citynameList.Add(new IDNameDescription(ConvertHelper.ObjectToInt(item.CityID), item.CityName, item.CityName));
            }

            QueryInfo<T_Cm_District> queryInfo1 = new QueryInfo<T_Cm_District>();
            ICmDistrictDal _district = UIHelper.Resolve<ICmDistrictDal>();
            List<dynamic> districtList = _district.Select(queryInfo1).ToList();
            foreach (var item in districtList)
            {

                citynameList.Add(new IDNameDescription(ConvertHelper.ObjectToInt(item.DistrictID), CombineCity(item.CityName, item.DistrictName), item.DistrictName));
            }

            city_customelookup.DataSource = citynameList;
            city_customelookup.DataBind();

            //设置当前登入人员所在地区
            if (this.IsDefault)
            {
                long? districtID = UserProvide.GetCurrentDistrictaID();
                if (districtID.HasValue && districtID > 0)
                {
                    T_Cm_District district = _district.GetSingle(districtID);
                    if (null != district) city_customelookup.Value = district.DistrictName;
                }
            }
            else if (this.IsStartCity)
            {
                ICmConfigDal _config = UIHelper.Resolve<ICmConfigDal>();
                QueryInfo<T_Cm_Config> queryInfo = new QueryInfo<T_Cm_Config>();
                List<T_Cm_Config> configList = _config.GetList(queryInfo).ToList();
                T_Cm_Config config = configList.FirstOrDefault(p => p.parameter_name == ConfigType.StartCity.ToString());
                if (null != config)
                    city_customelookup.Value = config.parameter_value;
            }
            else if (this.IsEndCity)
            {
                ICmConfigDal _config = UIHelper.Resolve<ICmConfigDal>();
                QueryInfo<T_Cm_Config> queryInfo = new QueryInfo<T_Cm_Config>();
                List<T_Cm_Config> configList = _config.GetList(queryInfo).ToList();
                T_Cm_Config config = configList.FirstOrDefault(p => p.parameter_name == ConfigType.EndCity.ToString());
                if (null != config)
                    city_customelookup.Value = config.parameter_value;
            }
        }
    }
}