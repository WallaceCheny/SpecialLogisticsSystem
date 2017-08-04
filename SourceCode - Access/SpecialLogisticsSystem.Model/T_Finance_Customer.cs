using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
   
      [DisplayName("客户结算信息")]
    public class T_Finance_Customer : Entity
    {
        #region "字段名称"
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Customer>(p => p.operator_man);
            }
        }
        /// <summary>
        ///Branch ID
        /// </summary>
        public static string BranchIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Customer>(p => p.branch_id);
            }
        }
        public static string AggregateAmountColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Customer>(p => p.aggregate_amount);
            }
        }
        public static string SettleAccountsColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Customer>(p => p.settle_accounts);
            }
        }
        public static string RealPaymentColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Customer>(p => p.real_payment);
            }
        }
        public static string OperatorColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Customer>(p => p.operator_man);
            }
        }
        private string _way_number;
        /// <summary>
        /// 运单号
        /// </summary>
        [NoColumn()]
        public string way_number
        {
            get { return _way_number; }
            set { _way_number = value; }
        }
        private decimal _aggregate_amount;
        /// <summary>
        /// 单据总额
        /// </summary>
        [NoColumn()]
        public decimal aggregate_amount
        {
            get { return _aggregate_amount; }
            set { _aggregate_amount = value; }
        }
        #endregion
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
        /// 票据编号
        /// </summary>
        public string settle_number
        {
            get { return _settle_number; }
            set { _settle_number = value; }
        }
        private Guid _way_id;
        /// <summary>
        /// 关联运单
        /// </summary>
        public Guid way_id
        {
            get { return _way_id; }
            set { _way_id = value; }
        }
        private decimal _receipts_totle;
        /// <summary>
        /// 单据总额
        /// </summary>
        public decimal receipts_totle
        {
            get { return _receipts_totle; }
            set { _receipts_totle = value; }
        }
        private decimal _already_payment;
        /// <summary>
        /// 已结
        /// </summary>
        public decimal already_payment
        {
            get { return _already_payment; }
            set { _already_payment = value; }
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
        private decimal _bring_payment;
        /// <summary>
        /// 提付金额
        /// </summary>
        public decimal bring_payment
        {
            get { return _bring_payment; }
            set { _bring_payment = value; }
        }
        private decimal _add_payment;
        /// <summary>
        /// 加送货费
        /// </summary>
        public decimal add_payment
        {
            get { return _add_payment; }
            set { _add_payment = value; }
        }
        private bool _is_collected;
        /// <summary>
        /// 货款未收
        /// </summary>
        public bool is_collected
        {
            get { return _is_collected; }
            set { _is_collected = value; }
        }
        private decimal _discount;
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        private decimal _settle_accounts;
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal settle_accounts
        {
            get { return _settle_accounts; }
            set { _settle_accounts = value; }
        }
        private DateTime _collection_day;
        /// <summary>
        /// 收款日期
        /// </summary>
        public DateTime collection_day
        {
            get { return _collection_day; }
            set { _collection_day = value; }
        }
        private string _settle_mode;
        /// <summary>
        /// 结算方式
        /// </summary>
        public string settle_mode
        {
            get { return _settle_mode; }
            set { _settle_mode = value; }
        }
        private string _settle_memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string settle_memo
        {
            get { return _settle_memo; }
            set { _settle_memo = value; }
        }
        private string _settl_type;
        /// <summary>
        /// 结算类别（发货方结算，收货方结算）
        /// </summary>
        public string settl_type
        {
            get { return _settl_type; }
            set { _settl_type = value; }
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

