using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("角色信息")]
    public class T_Cm_Role : Entity
    {
        public static string PropertyId { get { return DynamicPropertyHelper.GetPropertyName<T_Cm_Role>(p => p.id); } }
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
        /// role_type
        /// </summary>		
        private string _role_type;
        public string role_type
        {
            get { return _role_type; }
            set { _role_type = value; }
        }
        /// <summary>
        /// role_name
        /// </summary>		
        private string _role_name;
        public string role_name
        {
            get { return _role_name; }
            set { _role_name = value; }
        }
        /// <summary>
        /// description
        /// </summary>		
        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// update_date
        /// </summary>		
        private string _update_date;
        public string update_date
        {
            get { return _update_date; }
            set { _update_date = value; }
        }
        /// <summary>
        /// 是否是管理员
        /// </summary>		
        private bool _is_admin;
        public bool is_admin
        {
            get { return _is_admin; }
            set { _is_admin = value; }
        }

    }
}

