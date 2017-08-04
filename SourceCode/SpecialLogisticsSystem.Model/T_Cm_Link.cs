using System;
using System.ComponentModel;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.Model
{
    //联系人信息
     [DisplayName("联系人信息")]
    public class T_Cm_Link : Entity
    {
        /// <summary>
        /// 联系人
        /// </summary>
        public static string LinkNameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Link>(p => p.link_name);
            }
        }

        /// <summary>
        /// id
        /// </summary>		
        private Guid _id;
        [PrimaryKey(true)]
        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>		
        private string _link_name;
        public string link_name
        {
            get { return _link_name; }
            set { _link_name = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>		
        private string _link_telephone;
        public string link_telephone
        {
            get { return _link_telephone; }
            set { _link_telephone = value; }
        }
        /// <summary>
        /// 手机
        /// </summary>		
        private string _link_mobilephone;
        public string link_mobilephone
        {
            get { return _link_mobilephone; }
            set { _link_mobilephone = value; }
        }
        /// <summary>
        /// 省
        /// </summary>		
        private long _link_province;
        public long link_province
        {
            get { return _link_province; }
            set { _link_province = value; }
        }
        /// <summary>
        /// 市
        /// </summary>		
        private long _link_city;
        public long link_city
        {
            get { return _link_city; }
            set { _link_city = value; }
        }
        /// <summary>
        /// 区
        /// </summary>		
        private long _link_district;
        public long link_district
        {
            get { return _link_district; }
            set { _link_district = value; }
        }
        /// <summary>
        ///显示如：福建 - 南平 -延平
        /// </summary>
        public string link_area { get; set; }
        /// <summary>
        /// 地址
        /// </summary>		
        private string _link_address;
        public string link_address
        {
            get { return _link_address; }
            set { _link_address = value; }
        }
        /// <summary>
        /// email
        /// </summary>		
        private string _link_email;
        public string link_email
        {
            get { return _link_email; }
            set { _link_email = value; }
        }
        /// <summary>
        /// 传真
        /// </summary>		
        private string _link_fax;
        public string link_fax
        {
            get { return _link_fax; }
            set { _link_fax = value; }
        }
        /// <summary>
        /// 经度
        /// </summary>		
        private decimal _link_longitude;
        public decimal link_longitude
        {
            get { return _link_longitude; }
            set { _link_longitude = value; }
        }
        /// <summary>
        /// 纬度
        /// </summary>		
        private decimal _link_latitude;
        public decimal link_latitude
        {
            get { return _link_latitude; }
            set { _link_latitude = value; }
        }
        /// <summary>
        /// QQ
        /// </summary>		
        private string _link_qq;
        public string link_QQ
        {
            get { return _link_qq; }
            set { _link_qq = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _link_memo;
        public string link_memo
        {
            get { return _link_memo; }
            set { _link_memo = value; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>		
        private string _link_identity_number;
        public string link_identity_number
        {
            get { return _link_identity_number; }
            set { _link_identity_number = value; }
        }
      
    }
}

