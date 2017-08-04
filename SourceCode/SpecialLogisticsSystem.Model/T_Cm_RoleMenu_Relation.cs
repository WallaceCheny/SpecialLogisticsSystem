using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("菜单与角色权限")]
    public class T_Cm_RoleMenu_Relation : Entity
    {
        #region 获得字段名称
        public static string PropertyMenuID { get { return DynamicPropertyHelper.GetPropertyName<T_Cm_RoleMenu_Relation>(p => p.menu_id); } }
        public static string PropertyRoleID { get { return DynamicPropertyHelper.GetPropertyName<T_Cm_RoleMenu_Relation>(p => p.role_id); } }
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
        /// 关联分支机构
        /// </summary>		
        private Guid _branch_id;
        public Guid branch_id
        {
            get { return _branch_id; }
            set { _branch_id = value; }
        }
        /// <summary>
        /// role_id
        /// </summary>		
        private Guid _role_id;
        public Guid role_id
        {
            get { return _role_id; }
            set { _role_id = value; }
        }
        /// <summary>
        /// menu_id
        /// </summary>		
        private Guid _menu_id;
        public Guid menu_id
        {
            get { return _menu_id; }
            set { _menu_id = value; }
        }

    }
}

