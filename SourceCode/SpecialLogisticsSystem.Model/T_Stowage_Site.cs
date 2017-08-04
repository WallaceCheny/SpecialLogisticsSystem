using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace SpecialLogisticsSystem.Model
{
    //专线配载途经站点
    public class T_Stowage_Site : Entity
    {
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
        private Guid _main_id;
        /// <summary>
        /// 关联配载发车
        /// </summary>	
        public Guid main_id
        {
            get { return _main_id; }
            set { _main_id = value; }
        }
        private int _site_order;
        /// <summary>
        /// 顺序
        /// </summary>	
        public int site_order
        {
            get { return _site_order; }
            set { _site_order = value; }
        }
        private Guid _compay_ide;
        /// <summary>
        /// 关联站点（卸货站）
        /// </summary>	
        public Guid compay_ide
        {
            get { return _compay_ide; }
            set { _compay_ide = value; }
        }
        private int _unload_number;
        /// <summary>
        /// 卸货数量
        /// </summary>	
        public int unload_number
        {
            get { return _unload_number; }
            set { _unload_number = value; }
        }
        private decimal _reach_payment;
        /// <summary>
        /// 到付款
        /// </summary>	
        public decimal reach_payment
        {
            get { return _reach_payment; }
            set { _reach_payment = value; }
        }

    }
}

