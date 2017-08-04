using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("运单追踪")]
    public class T_Way_Track : Entity
    {
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
        private Guid _bill_id;
        /// <summary>
        /// 管理运单号
        /// </summary>	
        public Guid bill_id
        {
            get { return _bill_id; }
            set { _bill_id = value; }
        }
        private DateTime _track_date;
        /// <summary>
        /// 跟踪日期
        /// </summary>	
        public DateTime track_date
        {
            get { return _track_date; }
            set { _track_date = value; }
        }
        private string _track_description;
        /// <summary>
        /// 跟踪信息
        /// </summary>	
        public string track_description
        {
            get { return _track_description; }
            set { _track_description = value; }
        }
        private bool _is_inside;
        /// <summary>
        /// 是否内部信息
        /// </summary>	
        public bool is_inside
        {
            get { return _is_inside; }
            set { _is_inside = value; }
        } 
    }
}

