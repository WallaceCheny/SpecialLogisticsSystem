using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
namespace SpecialLogisticsSystem.Model
{
    //中转外包货物清单
    public class T_Transfer_Detail : Entity
    {
        public static string MainIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Transfer_Detail>(p => p.main_id);
            }
        }
        #region 计算列
        /// <summary>
        /// 货物信息
        /// </summary>
        [NoColumn]
        public dynamic production
        {
            get
            {
                return CodeName.Instance.iCodeName.GetProduction(this.production_id);
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
        private Guid _main_id;
        /// <summary>
        /// 关联中转外包
        /// </summary>
        public Guid main_id
        {
            get { return _main_id; }
            set { _main_id = value; }
        }
        private Guid _production_id;
        /// <summary>
        /// 货物信息
        /// </summary>
        public Guid production_id
        {
            get { return _production_id; }
            set { _production_id = value; }
        }
        private string _service_no;
        /// <summary>
        /// 服务商单号
        /// </summary>
        public string service_no
        {
            get { return _service_no; }
            set { _service_no = value; }
        }
        private decimal _transfer_bill;
        /// <summary>
        /// 中转费
        /// </summary>
        public decimal transfer_bill
        {
            get { return _transfer_bill; }
            set { _transfer_bill = value; }
        }
    }
}

