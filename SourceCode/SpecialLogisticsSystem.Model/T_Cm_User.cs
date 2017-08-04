using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Model
{
    [Serializable]
    [DataContract(Name = "User")]
    [DisplayName("用户信息")]
    public class T_Cm_User : Entity
    {
        #region "字段名称"
        public static string UserNameColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_User>(p => p.user_name);
            }
        }
        public static string IdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_User>(p => p.id);
            }
        }
        public static string BranchIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_User>(p => p.branch_id);
            }
        }
        public static string ShowBranchColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_User>(p => p.can_show_branch);
            }
        }
        /// <summary>
        /// def_show_branch
        /// </summary>
        public static string DefShowBranchColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_User>(p => p.def_show_branch);
            }
        }
        public static string UserStatusColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_User>(p => p.user_status);
            }
        }
        public static string EmpIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_User>(p => p.emp_Info_Id);
            }
        }
        /// <summary>
        /// can_show_branch
        /// </summary>
        public static string CanShowBranchColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_User>(p => p.can_show_branch);
            }
        }

        /// <summary>
        /// 标记改用户是否是超级管理员
        /// </summary>
        public static string IsAdminColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_User>(p => p.is_admin);
            }
        }
        #endregion
       
        [DataMember]
        public string Idstr
        {
            get { return _id == Guid.Empty ? string.Empty : _id.ToString(); }
            set { if (!string.IsNullOrEmpty(value))id = new System.Guid(value); }
        }
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
        [DataMember]
        public Guid branch_id
        {
            get { return _branch_id; }
            set { _branch_id = value; }
        }
        /// <summary>
        /// password
        /// </summary>		
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// user_name
        /// </summary>		
        private string _user_name;
        [DataMember]
        public string user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }
        /// <summary>
        /// update_date
        /// </summary>		
        private DateTime _update_date;
        public DateTime update_date
        {
            get { return _update_date; }
            set { _update_date = value; }
        }
        /// <summary>
        /// emp_Info_Id
        /// </summary>		
        private Guid? _emp_info_id;
        [DataMember]
        public Guid? emp_Info_Id
        {
            get { return _emp_info_id; }
            set { _emp_info_id = value; }
        }
        /// <summary>
        /// emp_name
        /// </summary>		
        private string _emp_name;
        [DataMember]
        public string emp_name
        {
            get { return _emp_name; }
            set { _emp_name = value; }
        }
        /// <summary>
        /// 停用0、启用1、锁定2
        /// </summary>		
        private string _user_status;
        [DataMember]
        public string user_status
        {
            get { return _user_status; }
            set { _user_status = value; }
        }
        /// <summary>
        /// def_show_branch
        /// </summary>		
        private Guid? _def_show_branch;
        public Guid? def_show_branch
        {
            get { return _def_show_branch; }
            set { _def_show_branch = value; }
        }
        /// <summary>
        /// add_date
        /// </summary>		
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; }
        }
        /// <summary>
        /// update_opr
        /// </summary>		
        private string _update_opr;
        public string update_opr
        {
            get { return _update_opr; }
            set { _update_opr = value; }
        }
        /// <summary>
        /// can_show_branch
        /// </summary>		
        private string _can_show_branch;
        public string can_show_branch
        {
            get { return _can_show_branch; }
            set { _can_show_branch = value; }
        }
        /// <summary>
        /// accesskey
        /// </summary>		
        private string _accesskey;
        public string accesskey
        {
            get { return _accesskey; }
            set { _accesskey = value; }
        }
        /// <summary>
        /// 标记改用户是否是超级管理员
        /// </summary>		
        private bool _is_admin;
        [DataMember]
        public bool is_admin
        {
            get { return _is_admin; }
            set { _is_admin = value; }
        }        
    }
}

