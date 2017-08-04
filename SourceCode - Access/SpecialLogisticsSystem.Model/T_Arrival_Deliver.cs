using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("送货信息")]
    public class T_Arrival_Deliver : Entity
    {
        #region "字段名称"
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Arrival_Deliver>(p => p.warehousem_man);
            }
        }
        /// <summary>
        /// 车ID
        /// </summary>
        public static string CarIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Arrival_Deliver>(p => p.deliver_carno);
            }
        }
        /// <summary>
        ///Branch ID
        /// </summary>
        public static string BranchIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Arrival_Deliver>(p => p.branch_id);
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
        private Guid _branch_id;
        /// <summary>
        /// 送货网点
        /// </summary>
        public Guid branch_id
        {
            get { return _branch_id; }
            set { _branch_id = value; }
        }
        private DateTime _deliver_date;
        /// <summary>
        /// 送货日期
        /// </summary>
        public DateTime deliver_date
        {
            get { return _deliver_date; }
            set { _deliver_date = value; }
        }
        private string _deliver_number;
        /// <summary>
        /// 送货单号
        /// </summary>
        public string deliver_number
        {
            get { return _deliver_number; }
            set { _deliver_number = value; }
        }
        private Guid? _deliver_carno;
        /// <summary>
        /// 车牌号
        /// </summary>
        public Guid? deliver_carno
        {
            get { return _deliver_carno; }
            set { _deliver_carno = value; }
        }
        private string _deliver_man;
        /// <summary>
        /// 送货员
        /// </summary>
        public string deliver_man
        {
            get { return _deliver_man; }
            set { _deliver_man = value; }
        }
        private Guid _warehousem_man;
        /// <summary>
        /// 仓管员
        /// </summary>
        public Guid warehousem_man
        {
            get { return _warehousem_man; }
            set { _warehousem_man = value; }
        }
        private string _deliver_statue;
        /// <summary>
        /// 状态
        /// </summary>
        public string deliver_statue
        {
            get { return _deliver_statue; }
            set { _deliver_statue = value; }
        }
        private string _deliver_barcode;
        /// <summary>
        /// 条码
        /// </summary>
        public string deliver_barcode
        {
            get { return _deliver_barcode; }
            set { _deliver_barcode = value; }
        }
    }
}

