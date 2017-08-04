using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
namespace SpecialLogisticsSystem.Model
{
    //省份信息
    public class T_Cm_Province : Entity
    {
        /// <summary>
        /// ProvinceID
        /// </summary>
        public static string ProvinceidColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Province>(p => p.ProvinceID);
            }
        }
        /// <summary>
        /// ProvinceName
        /// </summary>
        public static string ProvincenameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Province>(p => p.ProvinceName);
            }
        }
        /// <summary>
        /// ProvinceID
        /// </summary>		
        private long _provinceid;
        [PrimaryKey(true)]
        public long ProvinceID
        {
            get { return _provinceid; }
            set { _provinceid = value; }
        }
        /// <summary>
        /// ProvinceName
        /// </summary>		
        private string _provincename;
        public string ProvinceName
        {
            get { return _provincename; }
            set { _provincename = value; }
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

