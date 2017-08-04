using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace SpecialLogisticsSystem.Model
{
    //货款结算
    public class T_Finance_Goods : Entity
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
        private Guid _way_id;
        /// <summary>
        /// 关联运单
        /// </summary>	
        public Guid way_id
        {
            get { return _way_id; }
            set { _way_id = value; }
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
        private decimal _collection_amount;
        /// <summary>
        /// 代收款
        /// </summary>	
        public decimal collection_amount
        {
            get { return _collection_amount; }
            set { _collection_amount = value; }
        }
        private decimal _goods_deduct;
        /// <summary>
        /// 货款扣
        /// </summary>	
        public decimal goods_deduct
        {
            get { return _goods_deduct; }
            set { _goods_deduct = value; }
        }
        private decimal _settle_amount;
        /// <summary>
        /// 结算金额
        /// </summary>	
        public decimal settle_amount
        {
            get { return _settle_amount; }
            set { _settle_amount = value; }
        }
        private string _settle_type;
        /// <summary>
        /// 结算类型
        /// </summary>	
        public string settle_type
        {
            get { return _settle_type; }
            set { _settle_type = value; }
        }
        private DateTime _settle_date;
        /// <summary>
        /// 结算日期
        /// </summary>	
        public DateTime settle_date
        {
            get { return _settle_date; }
            set { _settle_date = value; }
        }
        private decimal _amount_get;
        /// <summary>
        /// 货款收回
        /// </summary>	
        public decimal amount_get
        {
            get { return _amount_get; }
            set { _amount_get = value; }
        } 
    }
}

