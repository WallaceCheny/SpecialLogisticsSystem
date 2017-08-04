using System;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Model
{
    [DisplayName("客户资料管理")]
    public class T_Cm_Customer : Entity
    {
        /// <summary>
        /// 关联联系人
        /// </summary>		
        private T_Cm_Link _link;
        [NoColumn()]
        public T_Cm_Link link
        {
            get
            {
                if (link_id != Guid.Empty && _link==null)
                {
                    _link = CodeName.Instance.iCodeName.GetLink(link_id);
                }
                return _link;
            }
            set
            {
                _link = value;
                _link_id = value.id;
            }
        }
        private string _link_name;
        /// <summary>
        /// 联系人
        /// </summary>		
        [NoColumn()]
        public string link_name
        {
            get { return link == null ? _link_name : link.link_name; }
            set { _link_name = value; }
        }
        /// <summary>
        /// 手机
        /// </summary>		
        [NoColumn()]
        public string link_mobilephone
        {
            get { return link == null ? string.Empty : link.link_mobilephone; }
        }
        /// <summary>
        ///显示如：福建 - 南平 -延平
        /// </summary>
        [NoColumn()]
        public string link_area { get { return link == null ? string.Empty : link.link_area; } }
        /// <summary>
        /// 地址
        /// </summary>		
        [NoColumn()]
        public string link_address
        {
            get { return link == null ? string.Empty : link.link_address; } 
        }
        /// <summary>
        /// 联系人ID列名
        /// </summary>
        public static string LinkIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Customer>(p => p.link_id);
            }
        }
        /// <summary>
        /// ID列名
        /// </summary>
        public static string IDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Customer>(p => p.id);
            }
        }
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Customer>(p => p.emp_id);
            }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public static string CustomerTypeColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Customer>(p => p.customer_type);
            }
        }
        /// <summary>
        /// 关联发货人
        /// </summary>
        public static string SenderIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Customer>(p => p.sender_id);
            }
        }
        /// <summary>
        /// 关联发货人
        /// </summary>
        public static string CustomerNameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Customer>(p => p.customer_name);
            }
        }
        private Guid _id;
        /// <summary>
        /// id
        /// </summary>
        [PrimaryKey(true)]
        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _customer_name;
        /// <summary>
        /// 名称
        /// </summary>	
        public string customer_name
        {
            get { return _customer_name; }
            set { _customer_name = value; }
        }
        private string _credit_level;
        /// <summary>
        /// 信用等级
        /// </summary>	
        public string credit_level
        {
            get { return _credit_level; }
            set { _credit_level = value; }
        }
        private string _customer_type;
        /// <summary>
        /// 类型
        /// </summary>	
        public string customer_type
        {
            get { return _customer_type; }
            set { _customer_type = value; }
        }
        private Guid _emp_id;
        /// <summary>
        /// 业务员
        /// </summary>	
        public Guid emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; }
        }
        private Guid _link_id;
        /// <summary>
        /// 关联联系人
        /// </summary>	
        public Guid link_id
        {
            get { return _link_id; }
            set { _link_id = value; }
        }
        private Guid _sender_id;
        /// <summary>
        /// 关联发货人
        /// </summary>	
        public Guid sender_id
        {
            get { return _sender_id; }
            set { _sender_id = value; }
        }
        private string _bank_username;
        /// <summary>
        /// 户名
        /// </summary>	
        public string bank_username
        {
            get { return _bank_username; }
            set { _bank_username = value; }
        }
        private string _bank_name;
        /// <summary>
        /// 开户行
        /// </summary>	
        public string bank_name
        {
            get { return _bank_name; }
            set { _bank_name = value; }
        }
        private string _bank_number;
        /// <summary>
        /// 帐号
        /// </summary>	
        public string bank_number
        {
            get { return _bank_number; }
            set { _bank_number = value; }
        }
        private string _bank_index;
        /// <summary>
        /// 行号
        /// </summary>	
        public string bank_index
        {
            get { return _bank_index; }
            set { _bank_index = value; }
        }
        private DateTime _create_date;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime create_date
        {
            get { return _create_date; }
            set { _create_date = value; }
        }
    }
}

