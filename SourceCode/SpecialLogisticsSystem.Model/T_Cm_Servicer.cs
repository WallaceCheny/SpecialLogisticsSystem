using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Model
{
     [DisplayName("服务商")]
    public class T_Cm_Servicer : Entity
    {
        #region "字段名称"

        /// <summary>
        /// id
        /// </summary>
        public static string IdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Servicer>(p => p.id);
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public static string NameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Servicer>(p => p.name);
            }
        }

        /// <summary>
        /// 编码
        /// </summary>
        public static string CodeColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Servicer>(p => p.code);
            }
        }

        /// <summary>
        /// customer_level
        /// </summary>
        public static string CustomerLevelColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Servicer>(p => p.customer_level);
            }
        }

        /// <summary>
        /// 关联联系人及地址
        /// </summary>
        public static string LinkIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Servicer>(p => p.link_id);
            }
        }

        /// <summary>
        /// 信用等级
        /// </summary>
        public static string CreditLevelColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Servicer>(p => p.credit_level);
            }
        }

        /// <summary>
        /// 是否停用
        /// </summary>
        public static string IsStopColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Servicer>(p => p.is_stop);
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
        private string _name;
        /// <summary>
        /// 名称
        /// </summary>	
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _code;
        /// <summary>
        /// 编码
        /// </summary>	
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _customer_level;
        /// <summary>
        /// customer_level
        /// </summary>	
        public string customer_level
        {
            get { return _customer_level; }
            set { _customer_level = value; }
        }
        private Guid _link_id;
        /// <summary>
        /// 关联联系人及地址
        /// </summary>	
        public Guid link_id
        {
            get { return _link_id; }
            set { _link_id = value; }
        }
        private string _credit_level;
        /// <summary>
        /// 信用等级
        /// </summary>	
        public string credit_level
        {
            get { return _credit_level; }
            set { _credit_level = value; }
        }
        private bool _is_stop;
        /// <summary>
        /// 是否停用
        /// </summary>	
        public bool is_stop
        {
            get { return _is_stop; }
            set { _is_stop = value; }
        }    
    }
}
