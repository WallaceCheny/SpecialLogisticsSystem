using System;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Model
{
    [DisplayName("托运单")]
    public class T_Way_Bill : Entity
    {
        /// <summary>
        /// 发货人列名
        /// </summary>
        public static string DeliverIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Way_Bill>(p => p.deliver_id);
            }
        }
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Way_Bill>(p => p.emp_id);
            }
        }
        /// <summary>
        /// 运单列名
        /// </summary>
        public static string WayNumberColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Way_Bill>(p => p.way_number);
            }
        }
        public static string ReceiveDateColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Way_Bill>(p => p.receive_date);
            }
        }
        public static string WayTypeColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Way_Bill>(p => p.way_type);
            }
        }
        public static string StatueColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Way_Bill>(p => p.bill_statue);
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
        private string _way_type;
        /// <summary>
        /// 订单类型(专线单,中转单)
        /// </summary>	
        public string way_type
        {
            get { return _way_type; }
            set { _way_type = value; }
        }
        private string _way_number;
        /// <summary>
        /// 运单号
        /// </summary>	
        public string way_number
        {
            get { return _way_number; }
            set { _way_number = value; }
        }
        private string _start_city;
        /// <summary>
        /// start_city
        /// </summary>	
        public string start_city
        {
            get { return _start_city; }
            set { _start_city = value; }
        }
        private string _end_city;
        /// <summary>
        /// 目的地
        /// </summary>	
        public string end_city
        {
            get { return _end_city; }
            set { _end_city = value; }
        }
        private string _pass_city;
        /// <summary>
        /// 经由
        /// </summary>	
        public string pass_city
        {
            get { return _pass_city; }
            set { _pass_city = value; }
        }
        private Guid? _deliver_id;
        /// <summary>
        /// 发货人
        /// </summary>
        public Guid? deliver_id
        {
            get { return _deliver_id; }
            set { _deliver_id = value; }
        }
        private string _deliver_mobile;
        /// <summary>
        /// 联系电话
        /// </summary>
        [NoColumn()]
        public string deliver_mobile
        {
            get { return _deliver_mobile; }
            set { _deliver_mobile = value; }
        }
        private string _deliver_area;
        /// <summary>
        /// 发货人所在地区
        /// </summary>
        [NoColumn()]
        public string deliver_area
        {
            get { return _deliver_area; }
            set { _deliver_area = value; }
        }
        private string _deliver_address;
        /// <summary>
        /// 发货人所在地址
        /// </summary>
        [NoColumn()]
        public string deliver_address
        {
            get { return _deliver_address; }
            set { _deliver_address = value; }
        }
        private Guid? _consignee_id;
        /// <summary>
        /// 收货人
        /// </summary>
        public Guid? consignee_id
        {
            get { return _consignee_id; }
            set { _consignee_id = value; }
        }
        private string _consignee_mobile;
        /// <summary>
        /// 收货人电话
        /// </summary>
        [NoColumn()]
        public string consignee_mobile
        {
            get { return _consignee_mobile; }
            set { _consignee_mobile = value; }
        }
        private string _consignee_area;
        /// <summary>
        /// 收货人所在地区
        /// </summary>
        [NoColumn()]
        public string consignee_area
        {
            get { return _consignee_area; }
            set { _consignee_area = value; }
        }
        private string _consignee_address;
        /// <summary>
        /// 收货人地址
        /// </summary>
        [NoColumn()]
        public string consignee_address
        {
            get { return _consignee_address; }
            set { _consignee_address = value; }
        }
        private decimal _aggregate_amount;
        /// <summary>
        /// 总金额
        /// </summary>	
        public decimal aggregate_amount
        {
            get { return _aggregate_amount; }
            set { _aggregate_amount = value; }
        }
        private string _clearing_type;
        /// <summary>
        /// 结算方式
        /// </summary>	
        public string clearing_type
        {
            get { return _clearing_type; }
            set { _clearing_type = value; }
        }
        private decimal _spot_payment;
        /// <summary>
        /// 现付
        /// </summary>	
        public decimal spot_payment
        {
            get { return _spot_payment; }
            set { _spot_payment = value; }
        }
        private decimal _pick_payment;
        /// <summary>
        /// 提付
        /// </summary>	
        public decimal pick_payment
        {
            get { return _pick_payment; }
            set { _pick_payment = value; }
        }
        private decimal _back_payment;
        /// <summary>
        /// 回付
        /// </summary>	
        public decimal back_payment
        {
            get { return _back_payment; }
            set { _back_payment = value; }
        }
        private decimal _production_payment;
        /// <summary>
        /// 货款扣
        /// </summary>	
        public decimal production_payment
        {
            get { return _production_payment; }
            set { _production_payment = value; }
        }
        private string _shipping_type;
        /// <summary>
        /// 运输方式
        /// </summary>	
        public string shipping_type
        {
            get { return _shipping_type; }
            set { _shipping_type = value; }
        }
        private string _delivery_type;
        /// <summary>
        /// 交货方式
        /// </summary>	
        public string delivery_type
        {
            get { return _delivery_type; }
            set { _delivery_type = value; }
        }
        private int _receipt_portion;
        /// <summary>
        /// 回单份数
        /// </summary>	
        public int receipt_portion
        {
            get { return _receipt_portion; }
            set { _receipt_portion = value; }
        }
        private string _receipt_number;
        /// <summary>
        /// 回单号
        /// </summary>	
        public string receipt_number
        {
            get { return _receipt_number; }
            set { _receipt_number = value; }
        }
        private string _collection_type;
        /// <summary>
        /// 代收类型
        /// </summary>	
        public string collection_type
        {
            get { return _collection_type; }
            set { _collection_type = value; }
        }
        private DateTime _receive_date;
        /// <summary>
        /// 接单日期
        /// </summary>	
        public DateTime receive_date
        {
            get { return _receive_date; }
            set { _receive_date = value; }
        }
        private decimal _bill_rebate;
        /// <summary>
        /// 回扣
        /// </summary>	
        public decimal bill_rebate
        {
            get { return _bill_rebate; }
            set { _bill_rebate = value; }
        }
        private string _bill_memo;
        /// <summary>
        /// 备注
        /// </summary>	
        public string bill_memo
        {
            get { return _bill_memo; }
            set { _bill_memo = value; }
        }
        private bool _fee_pay;
        /// <summary>
        /// 运货费现付（发货商已经把货物的送货费在发货站付情，但运费则是提付）
        /// </summary>	
        public bool fee_pay
        {
            get { return _fee_pay; }
            set { _fee_pay = value; }
        }
        private bool _fee_nopay;
        /// <summary>
        /// 运费现付未付（运单上面显示的运费已付，但实际运费未付，是回付或月结的付款方式）
        /// </summary>	
        public bool fee_nopay
        {
            get { return _fee_nopay; }
            set { _fee_nopay = value; }
        }
        private bool _fee_reback;
        /// <summary>
        /// 回扣已返（物流公司给发货商的回扣在运单未结算的情况下，已经将发货商的这一部分回扣付给了发货商）
        /// </summary>	
        public bool fee_reback
        {
            get { return _fee_reback; }
            set { _fee_reback = value; }
        }
        private Guid _bring_site;
        /// <summary>
        /// 提付网点
        /// </summary>	
        public Guid bring_site
        {
            get { return _bring_site; }
            set { _bring_site = value; }
        }
        private string _bring_man;
        /// <summary>
        /// 提付人
        /// </summary>	
        public string bring_man
        {
            get { return _bring_man; }
            set { _bring_man = value; }
        }
        private Guid _back_site;
        /// <summary>
        /// 回扣网点
        /// </summary>	
        public Guid back_site
        {
            get { return _back_site; }
            set { _back_site = value; }
        }
        private string _back_man;
        /// <summary>
        /// 回扣结算人
        /// </summary>	
        public string back_man
        {
            get { return _back_man; }
            set { _back_man = value; }
        }
        private string _bill_statue;
        /// <summary>
        /// 运单状态
        /// </summary>	
        public string bill_statue
        {
            get { return _bill_statue; }
            set { _bill_statue = value; }
        }
        private bool _is_hide;
        /// <summary>
        /// 是否隐藏
        /// </summary>	
        public bool is_hide
        {
            get { return _is_hide; }
            set { _is_hide = value; }
        }
        private decimal? _ticket_taxes;
        /// <summary>
        /// 票税
        /// </summary>
        public decimal? ticket_taxes
        {
            set { _ticket_taxes = value; }
            get { return _ticket_taxes; }
        }
        private string _freight_chinese;
        /// <summary>
        /// 运费合计大写金额
        /// </summary>
        public string freight_chinese
        {
            get { return MoneyHelper.GetMoneyString(this.aggregate_amount); }
            set {
                _freight_chinese=value;
            }
        }
        private Guid _emp_id;
        /// <summary>
        /// 经办人
        /// </summary>
        public Guid emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; }
        }
        private string _deliver_name;
        /// <summary>
        /// 发货人
        /// </summary>
        [NoColumn()]
        public string deliver_name
        {
            get { return _deliver_name; }
            set { _deliver_name = value; }
        }
        private string _consignee_name;
        /// <summary>
        /// 收货人
        /// </summary>
        [NoColumn()]
        public string consignee_name
        {
            get { return _consignee_name; }
            set { _consignee_name = value; }
        }        
    }
}

