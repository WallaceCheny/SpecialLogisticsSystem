using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{
    [DisplayName("系统的配置参数")]
    public class T_Cm_Config : Entity
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
        private string _parameter_name;
        /// <summary>
        /// 参数名称
        /// </summary>	
        public string parameter_name
        {
            get { return _parameter_name; }
            set { _parameter_name = value; }
        }
        private string _parameter_value;
        /// <summary>
        /// 值
        /// </summary>	
        public string parameter_value
        {
            get { return _parameter_value; }
            set { _parameter_value = value; }
        }
        private string _parameter_description;
        /// <summary>
        /// 描述
        /// </summary>	
        public string parameter_description
        {
            get { return _parameter_description; }
            set { _parameter_description = value; }
        }

    }
}

