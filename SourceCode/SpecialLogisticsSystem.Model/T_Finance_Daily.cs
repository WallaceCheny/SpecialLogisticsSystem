using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{

    [DisplayName("日常结算")]
    public class T_Finance_Daily : Entity
    {
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Daily>(p => p.operator_man);
            }
        }
        /// <summary>
        ///Branch ID
        /// </summary>
        public static string BranchIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Daily>(p => p.branch_id);
            }
        }
        /// <summary>
        ///配载信息
        /// </summary>
        public static string StowageIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Daily>(p => p.stowage_id);
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
        private string _settle_number;
        /// <summary>
        /// 结算编号
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
        private Guid _stowage_id;
        /// <summary>
        /// 关联发车单
        /// </summary>
        public Guid stowage_id
        {
            get { return _stowage_id; }
            set { _stowage_id = value; }
        }    
        private string _category_type;
        /// <summary>
        /// 科目
        /// </summary>
        public string category_type
        {
            get { return _category_type; }
            set { _category_type = value; }
        }
        private decimal _input_money;
        /// <summary>
        /// 收入
        /// </summary>
        public decimal input_money
        {
            get { return _input_money; }
            set { _input_money = value; }
        }
        private decimal _output_money;
        /// <summary>
        /// 支出
        /// </summary>
        public decimal output_money
        {
            get { return _output_money; }
            set { _output_money = value; }
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
        private Guid _operator_man;
        /// <summary>
        /// 负责人
        /// </summary>
        public Guid operator_man
        {
            get { return _operator_man; }
            set { _operator_man = value; }
        }
        private DateTime _input_date;
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime input_date
        {
            get { return _input_date; }
            set { _input_date = value; }
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
        private Guid _branch_id;
        /// <summary>
        /// 分支机构
        /// </summary>
        public Guid branch_id
        {
            get { return _branch_id; }
            set { _branch_id = value; }
        }
    }
}


