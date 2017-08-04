using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
namespace SpecialLogisticsSystem.Model
{
    //运单货物
    public class T_Way_Production : Entity
    {
        #region "字段名称"
        /// <summary>
        /// bill_id
        /// </summary>
        public static string BillIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Way_Production>(p => p.bill_id);
            }
        }
        #endregion
        #region 计算列
        /// <summary>
        /// 包装方式-名称
        /// </summary>
        [NoColumn]
        public string package_type_name
        {
            get
            {
                return CodeName.Instance.iCodeName.GetCodeName(CodeType.wrap_type, package_type);
            }
        }
        /// <summary>
        /// 总费用
        /// </summary>
        [NoColumn]
        public decimal total_price
        {
            get
            {
                decimal total=decimal.Zero;
                bool isFreeGet=CodeName.Instance.iCodeName.GetConfigResult(ConfigType.IsFreeGet);
                bool isFreeSet = CodeName.Instance.iCodeName.GetConfigResult(ConfigType.IsFreeSet);
                bool isFreeOther = CodeName.Instance.iCodeName.GetConfigResult(ConfigType.OtherIsFree);
                total = premium + freight + agency_fund;
                if (!isFreeGet)
                {
                    total += receive_expenses;
                }
                if(!isFreeSet)//送货费不免费的话，计入总运费
                {
                    total += delivery_expense; 
                }
                if (!isFreeOther)
                {
                    total += other_expenses;
                }
                return total;
            }
        }
        /// <summary>
        /// 计费方式-名称
        /// </summary>
        [NoColumn]
        public string charge_mode_name
        {
            get
            {
                return CodeName.Instance.iCodeName.GetCodeName(CodeType.price_type, _charge_mode);
            }
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
        private Guid _bill_id;
        /// <summary>
        /// 关联运单
        /// </summary>	
        public Guid bill_id
        {
            get { return _bill_id; }
            set { _bill_id = value; }
        }
        private string _production_name;
        /// <summary>
        /// 货物名称
        /// </summary>	
        public string production_name
        {
            get { return _production_name; }
            set { _production_name = value; }
        }
        private string _package_type;
        /// <summary>
        /// 包装方式
        /// </summary>	
        public string package_type
        {
            get { return _package_type; }
            set { _package_type = value; }
        }
        private int _production_number;
        /// <summary>
        /// 件数
        /// </summary>	
        public int production_number
        {
            get { return _production_number; }
            set { _production_number = value; }
        }
        private decimal _production_weight;
        /// <summary>
        /// 重量
        /// </summary>	
        public decimal production_weight
        {
            get { return _production_weight; }
            set { _production_weight = value; }
        }
        private decimal _production_size;
        /// <summary>
        /// 体积
        /// </summary>	
        public decimal production_size
        {
            get { return _production_size; }
            set { _production_size = value; }
        }
        private string _charge_mode;
        /// <summary>
        /// 计费方式
        /// </summary>	
        public string charge_mode
        {
            get { return _charge_mode; }
            set { _charge_mode = value; }
        }
        private decimal _freight_rates;
        /// <summary>
        /// 运价
        /// </summary>	
        public decimal freight_rates
        {
            get { return _freight_rates; }
            set { _freight_rates = value; }
        }
        private decimal _freight;
        /// <summary>
        /// 运费
        /// </summary>	
        public decimal freight
        {
            get { return _freight; }
            set { _freight = value; }
        }
        private decimal _agency_fund;
        /// <summary>
        /// 代收款
        /// </summary>	
        public decimal agency_fund
        {
            get { return _agency_fund; }
            set { _agency_fund = value; }
        }
        private decimal _coverage;
        /// <summary>
        /// 保额
        /// </summary>	
        public decimal coverage
        {
            get { return _coverage; }
            set { _coverage = value; }
        }
        private decimal _premium;
        /// <summary>
        /// 保险费
        /// </summary>	
        public decimal premium
        {
            get { return _premium; }
            set { _premium = value; }
        }
        private decimal _delivery_expense;
        /// <summary>
        /// 送货费
        /// </summary>	
        public decimal delivery_expense
        {
            get { return _delivery_expense; }
            set { _delivery_expense = value; }
        }
        private decimal _receive_expenses;
        /// <summary>
        /// 接货费
        /// </summary>
        public decimal receive_expenses
        {
            get { return _receive_expenses; }
            set { _receive_expenses = value; }
        }     
        private decimal _other_expenses;
        /// <summary>
        /// 其他费用
        /// </summary>	
        public decimal other_expenses
        {
            get { return _other_expenses; }
            set { _other_expenses = value; }
        }        
    }
}

