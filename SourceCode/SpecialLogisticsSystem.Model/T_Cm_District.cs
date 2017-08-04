using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("所在地区信息")]
    public class T_Cm_District : Entity
    {
        #region "字段名称"
        /// <summary>
        /// DistrictID
        /// </summary>
        public static string DistrictidColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_District>(p => p.DistrictID);
            }
        }
        /// <summary>
        /// DistrictName
        /// </summary>
        public static string DistrictnameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_District>(p => p.DistrictName);
            }
        }
        /// <summary>
        /// CityID
        /// </summary>
        public static string CityidColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_District>(p => p.CityID);
            }
        }
        #endregion
        /// <summary>
        /// DistrictID
        /// </summary>		
        private long _districtid;
        [PrimaryKey(true)]
        public long DistrictID
        {
            get { return _districtid; }
            set { _districtid = value; }
        }
        /// <summary>
        /// DistrictName
        /// </summary>		
        private string _districtname;
        public string DistrictName
        {
            get { return _districtname; }
            set { _districtname = value; }
        }
        /// <summary>
        /// CityID
        /// </summary>		
        private long _cityid;
        public long CityID
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        /// <summary>
        /// DateCreated
        /// </summary>		
        private DateTime _datecreated;
        public DateTime DateCreated
        {
            get { return _datecreated; }
            set { _datecreated = value; }
        }
        /// <summary>
        /// DateUpdated
        /// </summary>		
        private DateTime _dateupdated;
        public DateTime DateUpdated
        {
            get { return _dateupdated; }
            set { _dateupdated = value; }
        }

    }
}

