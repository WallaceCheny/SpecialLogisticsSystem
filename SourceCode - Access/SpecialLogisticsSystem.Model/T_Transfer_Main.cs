using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("中转外包")]
    public class T_Transfer_Main : Entity
    {
        /// <summary>
        /// 中转编号列
        /// </summary>
        public static string TransferNumberColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Transfer_Main>(p => p.transfer_number);
            }
        }
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Transfer_Main>(p => p.transfer_operator);
            }
        }
        public static string ServiceIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Transfer_Main>(p => p.service_id);
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
        private string _transfer_number;
        /// <summary>
        /// 中转批次
        /// </summary>
        public string transfer_number
        {
            get { return _transfer_number; }
            set { _transfer_number = value; }
        }
        private string _transfer_statue;
        /// <summary>
        /// 中转状态
        /// </summary>
        public string transfer_statue
        {
            get { return _transfer_statue; }
            set { _transfer_statue = value; }
        }
        private DateTime _transfer_date;
        /// <summary>
        /// 中转日期
        /// </summary>
        public DateTime transfer_date
        {
            get { return _transfer_date; }
            set { _transfer_date = value; }
        }
        private Guid _service_id;
        /// <summary>
        /// 服务商
        /// </summary>
        public Guid service_id
        {
            get { return _service_id; }
            set { _service_id = value; }
        }
        private string _service_name;
        /// <summary>
        /// 服务商
        /// </summary>
        [NoColumn()]
        public string service_name
        {
            get { return _service_name; }
            set { _service_name = value; }
        }
        private string _get_address;
        /// <summary>
        /// 提货地址
        /// </summary>
         [NoColumn()]
        public string get_address
        {
            get { return _get_address; }
            set { _get_address = value; }
        }
         private string _link_name;
        /// <summary>
        /// 联系人
        /// </summary>
         [NoColumn()]
        public string link_name
        {
            get { return _link_name; }
            set { _link_name = value; }
        }
        private string _link_mobilephone;
        /// <summary>
        /// 联系电话
        /// </summary>
         [NoColumn()]
        public string link_mobilephone
        {
            get { return _link_mobilephone; }
            set { _link_mobilephone = value; }
        }
        private string _go_type;
        /// <summary>
        /// 配载方式
        /// </summary>
        public string go_type
        {
            get { return _go_type; }
            set { _go_type = value; }
        }
        private string _settle_type;
        /// <summary>
        /// 结算方式
        /// </summary>
        public string settle_type
        {
            get { return _settle_type; }
            set { _settle_type = value; }
        }
        private string _connect_type;
        /// <summary>
        /// 交接方式
        /// </summary>
        public string connect_type
        {
            get { return _connect_type; }
            set { _connect_type = value; }
        }
        private Guid _transfer_operator;
        /// <summary>
        /// 经办人
        /// </summary>
        public Guid transfer_operator
        {
            get { return _transfer_operator; }
            set { _transfer_operator = value; }
        }
        private string _transfer_memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string transfer_memo
        {
            get { return _transfer_memo; }
            set { _transfer_memo = value; }
        }
    }
}

