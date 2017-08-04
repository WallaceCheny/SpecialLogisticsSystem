using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("司机结算")]
    public class T_Finance_Driver : Entity
	{
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Driver>(p => p.operator_man);
            }
        }
        /// <summary>
        ///Branch ID
        /// </summary>
        public static string BranchIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Driver>(p => p.branch_id);
            }
        }
        /// <summary>
        ///配载信息
        /// </summary>
        public static string StowageIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Finance_Driver>(p => p.stowage_id);
            }
        }
        private string _stowage_number;
        /// <summary>
        /// 车次编号
        /// </summary>
        [NoColumn()]
        public string stowage_number
        {
            get { return _stowage_number; }
            set { _stowage_number = value; }
        }

        private string _link_name;
        /// <summary>
        /// 司机
        /// </summary>
        [NoColumn()]
        public string link_name
        {
            get { return _link_name; }
            set { _link_name = value; }
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
        private Guid _stowage_id;
        /// <summary>
        /// 关联发车信息
        /// </summary>
        public Guid stowage_id
        {
            get { return _stowage_id; }
            set { _stowage_id = value; }
        }
        private decimal _deduct_money;
        /// <summary>
        /// 扣款金额
        /// </summary>
        public decimal deduct_money
        {
            get { return _deduct_money; }
            set { _deduct_money = value; }
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
        private decimal _real_money;
        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal real_money
        {
            get { return _real_money; }
            set { _real_money = value; }
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
        private string _settle_type;
        /// <summary>
        /// 结算类型（预付款，到付，回付）
        /// </summary>
        public string settle_type
        {
            get { return _settle_type; }
            set { _settle_type = value; }
        }
        private string _driver_memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string driver_memo
        {
            get { return _driver_memo; }
            set { _driver_memo = value; }
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
        private DateTime _input_date;
        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime input_date
        {
            get { return _input_date; }
            set { _input_date = value; }
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
	}
}

