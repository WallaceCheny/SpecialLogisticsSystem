using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
     [DisplayName("货物签收信息")]
    public class T_Arrival_Sign : Entity
    {
        /// <summary>
        /// 员工列名
        /// </summary>
        public static string EmpIDColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Arrival_Sign>(p => p.emp_id);
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
        private Guid _way_id;
        /// <summary>
        /// 运单信息
        /// </summary>
        public Guid way_id
        {
            get { return _way_id; }
            set { _way_id = value; }
        }
        private string _signer;
        /// <summary>
        /// 签收人
        /// </summary>
        public string signer
        {
            get { return _signer; }
            set { _signer = value; }
        }
        private string _signer_identity;
        /// <summary>
        /// 证件号
        /// </summary>
        public string signer_identity
        {
            get { return _signer_identity; }
            set { _signer_identity = value; }
        }
        private string _signer_memo;
        /// <summary>
        /// 签收说明
        /// </summary>
        public string signer_memo
        {
            get { return _signer_memo; }
            set { _signer_memo = value; }
        }
        private DateTime _signer_date;
        /// <summary>
        /// 签收时间
        /// </summary>
        public DateTime signer_date
        {
            get { return _signer_date; }
            set { _signer_date = value; }
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

