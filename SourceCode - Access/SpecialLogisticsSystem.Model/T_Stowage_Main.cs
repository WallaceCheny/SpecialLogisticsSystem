using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("专线配载信息")]
    public class T_Stowage_Main : Entity
    {
        #region "字段名称"
        /// <summary>
        /// 状态列名
        /// </summary>
        public static string StowageStatueColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Stowage_Main>(p => p.stowage_statue);
            }
        }
        /// <summary>
        /// 发车号列名
        /// </summary>
        public static string StowageNumberColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Stowage_Main>(p => p.stowage_number);
            }
        }
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Stowage_Main>(p => p.emp_id);
            }
        }
        /// <summary>
        /// 车ID
        /// </summary>
        public static string CarIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Stowage_Main>(p => p.car_id);
            }
        }
        /// <summary>
        /// 启运站
        /// </summary>
        public static string StartBranchColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Stowage_Main>(p => p.start_branch);
            }
        }
        /// <summary>
        /// 目的站
        /// </summary>
        public static string EndBranchColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Stowage_Main>(p => p.end_branch);
            }
        }
        /// <summary>
        /// 联系人
        /// </summary>		
        [NoColumn()]
        public string link_name
        {
            get;
            set;
        }
        /// <summary>
        /// 手机
        /// </summary>
        [NoColumn()]
        public string link_mobilephone
        {
            get;
            set;
        }
        /// <summary>
        /// 车牌号
        /// </summary>
        [NoColumn()]
        public string car_no
        {
            get;
            set;
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
        private string _stowage_number;
        /// <summary>
        /// 编号
        /// </summary>	
        public string stowage_number
        {
            get { return _stowage_number; }
            set { _stowage_number = value; }
        }
        private string _stowage_statue;
        /// <summary>
        /// 状态
        /// </summary>	
        public string stowage_statue
        {
            get { return _stowage_statue; }
            set { _stowage_statue = value; }
        }
        private DateTime _departure_time;
        /// <summary>
        /// 发车时间
        /// </summary>	
        public DateTime departure_time
        {
            get { return _departure_time; }
            set { _departure_time = value; }
        }
        private Guid _car_id;
        /// <summary>
        /// 车牌，司机，电话
        /// </summary>	
        public Guid car_id
        {
            get { return _car_id; }
            set { _car_id = value; }
        }
        private Guid _emp_id;
        /// <summary>
        /// 仓管员
        /// </summary>	
        public Guid emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; }
        }
        private long _start_city;
        /// <summary>
        /// 起运站
        /// </summary>	
        public long start_city
        {
            get { return _start_city; }
            set { _start_city = value; }
        }
        private string _main_memo;
        /// <summary>
        /// 备注
        /// </summary>	
        public string main_memo
        {
            get { return _main_memo; }
            set { _main_memo = value; }
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
        private decimal _prepay;
        /// <summary>
        /// 预付
        /// </summary>	
        public decimal prepay
        {
            get { return _prepay; }
            set { _prepay = value; }
        }
        private decimal _other_payment;
        /// <summary>
        /// 其他费用
        /// </summary>	
        public decimal other_payment
        {
            get { return _other_payment; }
            set { _other_payment = value; }
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
        private decimal _arrive_payment;
        /// <summary>
        /// 到付
        /// </summary>
        public decimal arrive_payment
        {
            get { return _arrive_payment; }
            set { _arrive_payment = value; }
        }
        private Guid _start_branch;
        /// <summary>
        /// 启运网点
        /// </summary>
        public Guid start_branch
        {
            get { return _start_branch; }
            set { _start_branch = value; }
        }
        private Guid _end_branch;
        /// <summary>
        /// 到达网点
        /// </summary>
        public Guid end_branch
        {
            get { return _end_branch; }
            set { _end_branch = value; }
        }
        private string _end_branch_linkname;
        /// <summary>
        /// 到达主任
        /// </summary>
        public string end_branch_linkname
        {
            get { return _end_branch_linkname; }
            set { _end_branch_linkname = value; }
        }
        private string _end_branch_linktelephone;
        /// <summary>
        /// 目的网点联系电话
        /// </summary>
        public string end_branch_linktelephone
        {
            get { return _end_branch_linktelephone; }
            set { _end_branch_linktelephone = value; }
        }
        private DateTime _plan_arrivle;
        /// <summary>
        /// 预计到达
        /// </summary>
        public DateTime plan_arrivle
        {
            get { return _plan_arrivle; }
            set { _plan_arrivle = value; }
        }        
    }
}

