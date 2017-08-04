using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("数据字典")]
    public class T_Cm_Code : Entity
    {
        public static string ActiveColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Code>(p => p.is_active);
            }
        }
        public static string NameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Code>(p => p.para_name);
            }
        }
        public static string ValueColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Code>(p => p.para_value);
            }
        }
        public static string TypeColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Code>(p => p.para_type);
            }
        }
        public static string TypeNameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Code>(p => p._para_type_name);
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
        private string _para_type;
        /// <summary>
        /// 参数类别
        /// </summary>	
        public string para_type
        {
            get { return _para_type; }
            set { _para_type = value; }
        }
        private string _para_value;
        /// <summary>
        /// 参数值
        /// </summary>	
        public string para_value
        {
            get { return _para_value; }
            set { _para_value = value; }
        }
        private string _para_type_name;
        /// <summary>
        /// 参数类别名称
        /// </summary>	
        public string para_type_name
        {
            get { return _para_type_name; }
            set { _para_type_name = value; }
        }
        private string _para_name;
        /// <summary>
        /// 参数名称
        /// </summary>	
        public string para_name
        {
            get { return _para_name; }
            set { _para_name = value; }
        }
        private string _para_demo;
        /// <summary>
        /// 备注
        /// </summary>	
        public string para_demo
        {
            get { return _para_demo; }
            set { _para_demo = value; }
        }
        private string _update_opr;
        /// <summary>
        /// update_opr
        /// </summary>	
        public string update_opr
        {
            get { return _update_opr; }
            set { _update_opr = value; }
        }
        private DateTime _update_date;
        /// <summary>
        /// update_date
        /// </summary>	
        public DateTime update_date
        {
            get { return _update_date; }
            set { _update_date = value; }
        }
        private int _sort;
        /// <summary>
        /// sort
        /// </summary>	
        public int sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        private string _eff_ind;
        /// <summary>
        /// eff_ind
        /// </summary>	
        public string eff_ind
        {
            get { return _eff_ind; }
            set { _eff_ind = value; }
        }
        private string _parent_value;
        /// <summary>
        /// parent_value
        /// </summary>	
        public string parent_value
        {
            get { return _parent_value; }
            set { _parent_value = value; }
        }
        private bool _is_active;
        /// <summary>
        /// 是否启用
        /// </summary>	
        public bool is_active
        {
            get { return _is_active; }
            set { _is_active = value; }
        }
        private bool _is_system;
        /// <summary>
        /// 是否是系统表,不可更改
        /// </summary>	
        public bool is_system
        {
            get { return _is_system; }
            set { _is_system = value; }
        }
        private bool _is_default;
        /// <summary>
        /// 是否是默认值
        /// </summary>
        public bool is_default
        {
            get { return _is_default; }
            set { _is_default = value; }
        }
    }
}

