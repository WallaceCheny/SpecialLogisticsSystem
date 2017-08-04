using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{

     [DisplayName("公司网点")]
    public class T_Cm_Branch : Entity
    {
        #region "字段名称"
        /// <summary>
        /// id
        /// </summary>
        public static string IdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.id);
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public static string NameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.name);
            }
        }

        /// <summary>
        /// 编码
        /// </summary>
        public static string CodeColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.code);
            }
        }

        /// <summary>
        /// 所属行业
        /// </summary>
        public static string IndustryColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.industry);
            }
        }

        /// <summary>
        /// 所有权类型
        /// </summary>
        public static string OwnershipColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.ownership);
            }
        }

        /// <summary>
        /// 简称
        /// </summary>
        public static string AbbreviationColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.abbreviation);
            }
        }

        /// <summary>
        /// 客户级别
        /// </summary>
        public static string CustomerLevelColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.customer_level);
            }
        }

        /// <summary>
        /// 关联联系人及地址
        /// </summary>
        public static string LinkIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.link_id);
            }
        }

        /// <summary>
        /// 网点类型
        /// </summary>
        public static string SiteTypeColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.site_type);
            }
        }

        /// <summary>
        /// 上级机构
        /// </summary>
        public static string ParentIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.parent_id);
            }
        }

        /// <summary>
        /// 信用等级
        /// </summary>
        public static string CreditLevelColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.credit_level);
            }
        }

        /// <summary>
        /// 类别：公司, 分支机构, 服务商
        /// </summary>
        public static string TypeColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.type);
            }
        }

        /// <summary>
        /// 是否是总公司
        /// </summary>
        public static string IsHeadquartersColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.is_headquarters);
            }
        }

        /// <summary>
        /// 是否停用
        /// </summary>
        public static string IsStopColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Branch>(p => p.is_stop);
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
        private string _industry;
        /// <summary>
        /// 所属行业
        /// </summary>
        public string industry
        {
            get { return _industry; }
            set { _industry = value; }
        }
        private string _ownership;
        /// <summary>
        /// 所有权类型
        /// </summary>
        public string ownership
        {
            get { return _ownership; }
            set { _ownership = value; }
        }
        private string _abbreviation;
        /// <summary>
        /// 简称
        /// </summary>
        public string abbreviation
        {
            get { return _abbreviation; }
            set { _abbreviation = value; }
        }
        private string _customer_level;
        /// <summary>
        /// 客户级别
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
        private string _site_type;
        /// <summary>
        /// 网点类型
        /// </summary>
        public string site_type
        {
            get { return _site_type; }
            set { _site_type = value; }
        }
        private Guid _parent_id;
        /// <summary>
        /// 上级机构
        /// </summary>
        public Guid parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
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
        private string _type;
        /// <summary>
        /// 类别：公司, 分支机构, 服务商
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private bool _is_headquarters;
        /// <summary>
        /// 是否是总公司
        /// </summary>
        public bool is_headquarters
        {
            get { return _is_headquarters; }
            set { _is_headquarters = value; }
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

