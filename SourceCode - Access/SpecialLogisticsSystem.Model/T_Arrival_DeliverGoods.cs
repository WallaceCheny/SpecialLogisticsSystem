using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    //送货明细
    [DisplayName("送货明细")]
    public class T_Arrival_DeliverGoods : Entity
    {
        public static string MainIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Arrival_DeliverGoods>(p => p.deliver_id);
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
        private Guid _deliver_id;
        /// <summary>
        /// 关联送货单
        /// </summary>
        public Guid deliver_id
        {
            get { return _deliver_id; }
            set { _deliver_id = value; }
        }
        private Guid _production_id;
        /// <summary>
        /// 关联产品
        /// </summary>
        public Guid production_id
        {
            get { return _production_id; }
            set { _production_id = value; }
        }
        private decimal _send_bill;
        /// <summary>
        /// 送货费
        /// </summary>
        public decimal send_bill
        {
            get { return _send_bill; }
            set { _send_bill = value; }
        }
    }
}

