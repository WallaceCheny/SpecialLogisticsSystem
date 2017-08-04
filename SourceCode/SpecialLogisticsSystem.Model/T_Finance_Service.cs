using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
      [DisplayName("服务商结算")]
    public class T_Finance_Service : Entity
    {
        /// <summary>
        /// 中转列名
        /// </summary>
        public static string TransferIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Service>(p => p.transfer_id);
            }
        }
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Service>(p => p.operator_man);
            }
        }
        /// <summary>
        ///Branch ID
        /// </summary>
        public static string BranchIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Service>(p => p.branch_id);
            }
        }

        private string _transfer_number;
        /// <summary>
        /// 中转号
        /// </summary>
        [NoColumn()]
        public string transfer_number
        {
            get { return _transfer_number; }
            set { _transfer_number = value; }
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
        private string _transfer_bill;
        /// <summary>
        /// 中转金额
        /// </summary>
        [NoColumn()]
        public string transfer_bill
        {
            get { return _transfer_bill; }
            set { _transfer_bill = value; }
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
        private string _settle_number;
        /// <summary>
        /// 单据号
        /// </summary>
        public string settle_number
        {
            get { return _settle_number; }
            set { _settle_number = value; }
        }
        private Guid _transfer_id;
        /// <summary>
        /// 中转单次
        /// </summary>
        public Guid transfer_id
        {
            get { return _transfer_id; }
            set { _transfer_id = value; }
        }
        private Guid _service_id;
        /// <summary>
        /// 关联服务商表
        /// </summary>
        public Guid service_id
        {
            get { return _service_id; }
            set { _service_id = value; }
        }
        private bool _is_arrivalpayment;
        /// <summary>
        /// 不结算运单到付
        /// </summary>
        public bool is_arrivalpayment
        {
            get { return _is_arrivalpayment; }
            set { _is_arrivalpayment = value; }
        }
        private decimal _transfer_payment;
        /// <summary>
        /// 中转金额
        /// </summary>
        public decimal transfer_payment
        {
            get { return _transfer_payment; }
            set { _transfer_payment = value; }
        }
        private decimal _arrival_payment;
        /// <summary>
        /// 运单到付
        /// </summary>
        public decimal arrival_payment
        {
            get { return _arrival_payment; }
            set { _arrival_payment = value; }
        }
        private decimal _settlement_payment;
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal settlement_payment
        {
            get { return _settlement_payment; }
            set { _settlement_payment = value; }
        }
        private decimal _real_payment;
        /// <summary>
        /// 实结金额
        /// </summary>
        public decimal real_payment
        {
            get { return _real_payment; }
            set { _real_payment = value; }
        }
        private decimal _already_payment;
        /// <summary>
        /// 已结金额
        /// </summary>
        public decimal already_payment
        {
            get { return _already_payment; }
            set { _already_payment = value; }
        }
        private string _settlement_mode;
        /// <summary>
        /// 结算方式
        /// </summary>
        public string settlement_mode
        {
            get { return _settlement_mode; }
            set { _settlement_mode = value; }
        }
        private DateTime _payment_date;
        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime payment_date
        {
            get { return _payment_date; }
            set { _payment_date = value; }
        }
        private string _service_memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string service_memo
        {
            get { return _service_memo; }
            set { _service_memo = value; }
        }
        private Guid _operator_man;
        /// <summary>
        /// 经办人
        /// </summary>
        public Guid operator_man
        {
            get { return _operator_man; }
            set { _operator_man = value; }
        }
        private Guid _branch_id;
        /// <summary>
        /// 所属机构
        /// </summary>
        public Guid branch_id
        {
            get { return _branch_id; }
            set { _branch_id = value; }
        }     
    }
}

