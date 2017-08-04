using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("员工可访问的机构")]
    public class T_Cm_UserBranch_Relation : Entity
    {

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
        /// 用户ID
        /// </summary>		
        private Guid _user_id;
        public Guid user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

    }
}

