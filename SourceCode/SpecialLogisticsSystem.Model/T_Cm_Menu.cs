using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("菜单管理")]
    public class T_Cm_Menu : Entity
    {
        #region 获得字段名称
        public static string IdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_Menu>(p => p.id);
            }
        }
        public static string ParentIdColumnName
        {
            get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Menu>(p => p.parent_id); }
        }
        public static string NameColumnName
        {
            get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Menu>(p => p.name); }
        }
        public static string IconColumnName
        {
            get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Menu>(p => p.icon); }
        }
        public static string TipColumnName
        {
            get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Menu>(p => p.tip); }
        }
        public static string ActionColumnName
        {
            get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Menu>(p => p.action); }
        }
        public static string OrderColumnName
        {
            get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Menu>(p => p.menu_order); }
        }
        public static string IsMainColumnName
        {
            get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Menu>(p => p._is_main); }
        }
        #endregion
        /// <summary>
        /// id
        /// </summary>	
        private Guid _id;
        [PrimaryKey(true)]
        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// branch_id
        /// </summary>		
        private string _branch_id;
        public string branch_id
        {
            get { return _branch_id; }
            set { _branch_id = value; }
        }
        /// <summary>
        /// name
        /// </summary>		
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// menu_order
        /// </summary>		
        private int _menu_order;
        public int menu_order
        {
            get { return _menu_order; }
            set { _menu_order = value; }
        }
        /// <summary>
        /// icon
        /// </summary>		
        private string _icon;
        public string icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        /// <summary>
        /// action
        /// </summary>		
        private string _action;
        public string action
        {
            get { return _action; }
            set { _action = value; }
        }
        /// <summary>
        /// 是否是主菜单
        /// </summary>		
        private bool _is_main;
        public bool is_main
        {
            get { return _is_main; }
            set { _is_main = value; }
        }
        /// <summary>
        /// tip
        /// </summary>		
        private string _tip;
        public string tip
        {
            get { return _tip; }
            set { _tip = value; }
        }
        /// <summary>
        /// parent_id
        /// </summary>		
        private Guid? _parent_id;
        public Guid? parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
        }
        /// <summary>
        /// help_html
        /// </summary>		
        private string _help_html;
        public string help_html
        {
            get { return _help_html; }
            set { _help_html = value; }
        }

    }
}

