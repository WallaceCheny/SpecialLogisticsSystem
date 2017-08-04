using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
      [DisplayName("用户角色配置")]
    public class T_Cm_UserRole_Relation : Entity
    {

        public static string RoleIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_UserRole_Relation>(p => p.role_id);
            }
        }
        public static string UserIdColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_UserRole_Relation>(p => p.user_id);
            }
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
        public Guid branch_id
        {
            get { return _branch_id; }
            set { _branch_id = value; }
        }
        /// <summary>
        /// role_id
        /// </summary>		
        private Guid? _role_id;
        public Guid? role_id
        {
            get { return _role_id; }
            set { _role_id = value; }
        }
        /// <summary>
        /// user_id
        /// </summary>		
        private Guid? _user_id;
        public Guid? user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

    }
}

