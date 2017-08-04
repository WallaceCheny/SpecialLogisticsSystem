using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
namespace SpecialLogisticsSystem.Model
{
    //专线配载货物明细
    public class T_Stowage_Detail : Entity
    {
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

        public static string MainIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Stowage_Detail>(p => p.main_id);
            }
        }
        public static string ProudctionIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Stowage_Detail>(p => p.production_id);
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
        private Guid _main_id;
        /// <summary>
        /// 关联配载发车
        /// </summary>
        public Guid main_id
        {
            get { return _main_id; }
            set { _main_id = value; }
        }
        private Guid _bill_id;
        /// <summary>
        /// 关联运单号
        /// </summary>
        public Guid bill_id
        {
            get { return _bill_id; }
            set { _bill_id = value; }
        }
        private int _production_number;
        /// <summary>
        /// 选出件数
        /// </summary>
        public int production_number
        {
            get { return _production_number; }
            set { _production_number = value; }
        }
        private Guid _production_id;
        /// <summary>
        /// 关联货物
        /// </summary>
        public Guid production_id
        {
            get { return _production_id; }
            set { _production_id = value; }
        }
    }
}

