using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
     [DisplayName("城市信息")]
    public class T_Cm_City : Entity
    {
        #region "字段名称"
        /// <summary>
        /// CityID
        /// </summary>
        public static string CityidColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_City>(p => p.CityID);
            }
        }
        /// <summary>
        /// CityName
        /// </summary>
        public static string CitynameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_City>(p => p.CityName);
            }
        }
        /// <summary>
        /// ProvinceID
        /// </summary>
        public static string ProvinceidColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_City>(p => p.ProvinceID);
            }
        }
        #endregion
        /// <summary>
        /// CityID
        /// </summary>		
        private long _cityid;
          [PrimaryKey(true)]
        public long CityID
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        /// <summary>
        /// CityName
        /// </summary>		
        private string _cityname;
        public string CityName
        {
            get { return _cityname; }
            set { _cityname = value; }
        }
        /// <summary>
        /// ZipCode
        /// </summary>		
        private string _zipcode;
        public string ZipCode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }
        /// <summary>
        /// ProvinceID
        /// </summary>		
        private long _provinceid;
        public long ProvinceID
        {
            get { return _provinceid; }
            set { _provinceid = value; }
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

