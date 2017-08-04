using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Model
{
    [DisplayName("到货管理")]
    public class T_Arrival_Main : Entity
    {
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Arrival_Main>(p => p.emp_id);
            }
        }
        /// <summary>
        /// 配载列名
        /// </summary>
        public static string StowageIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Arrival_Main>(p => p.stowage_id);
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
        private Guid _stowage_id;
        /// <summary>
        /// 关联发车信息
        /// </summary>
        public Guid stowage_id
        {
            get { return _stowage_id; }
            set { _stowage_id = value; }
        }
        private decimal _unload_size;
        /// <summary>
        /// 卸点体积
        /// </summary>
        public decimal unload_size
        {
            get { return _unload_size; }
            set { _unload_size = value; }
        }
        private decimal _unload_weight;
        /// <summary>
        /// 卸点重量
        /// </summary>
        public decimal unload_weight
        {
            get { return _unload_weight; }
            set { _unload_weight = value; }
        }
        private decimal _unload_fee;
        /// <summary>
        /// 卸货费
        /// </summary>
        public decimal unload_fee
        {
            get { return _unload_fee; }
            set { _unload_fee = value; }
        }
        private decimal _tranfer_fee;
        /// <summary>
        /// 中转费
        /// </summary>
        public decimal tranfer_fee
        {
            get { return _tranfer_fee; }
            set { _tranfer_fee = value; }
        }
        private decimal _send_fee;
        /// <summary>
        /// 送货费
        /// </summary>
        public decimal send_fee
        {
            get { return _send_fee; }
            set { _send_fee = value; }
        }
        private decimal _outside_fee;
        /// <summary>
        /// 外请搬运
        /// </summary>
        public decimal outside_fee
        {
            get { return _outside_fee; }
            set { _outside_fee = value; }
        }
        private decimal _other_fee;
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal other_fee
        {
            get { return _other_fee; }
            set { _other_fee = value; }
        }
        private DateTime _arrival_date;
        /// <summary>
        /// 到车日期
        /// </summary>
        public DateTime arrival_date
        {
            get { return _arrival_date; }
            set { _arrival_date = value; }
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
    }
}
