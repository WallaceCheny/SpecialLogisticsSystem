using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.Model
{
    [DisplayName("回扣发放")]
    public class T_Finance_Discount : Entity
    {
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Discount>(p => p.operator_man);
            }
        }
        /// <summary>
        ///Branch ID
        /// </summary>
        public static string BranchIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Discount>(p => p.branch_id);
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
        private decimal _bill_rebate;
        /// <summary>
        /// 回扣金额
        /// </summary>
        [NoColumn()]
        public decimal bill_rebate
        {
            get { return _bill_rebate; }
            set { _bill_rebate = value; }
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
        /// 单据编号
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
        private decimal _settle_money;
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal settle_money
        {
            get { return _settle_money; }
            set { _settle_money = value; }
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
        private string _settle_type;
        /// <summary>
        /// 结算方式
        /// </summary>
        public string settle_type
        {
            get { return _settle_type; }
            set { _settle_type = value; }
        }
        private string _remark;
        /// <summary>
        /// 摘要
        /// </summary>
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
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
        private DateTime _payment_date;
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime payment_date
        {
            get { return _payment_date; }
            set { _payment_date = value; }
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
