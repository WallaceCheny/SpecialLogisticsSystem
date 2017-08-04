using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model
{

    [DisplayName("车牌前缀信息")]
    public class T_Cm_CarArea : Entity
    {
        private int _cararea_id;
        /// <summary>
        /// cararea_id
        /// </summary>	
        [PrimaryKey(true)]
        public int cararea_id
        {
            get { return _cararea_id; }
            set { _cararea_id = value; }
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
        private string _province;
        /// <summary>
        /// 省份
        /// </summary>	
        public string province
        {
            get { return _province; }
            set { _province = value; }
        }
        private bool _is_top;
        /// <summary>
        /// 是否默认
        /// </summary>	
        public bool is_top
        {
            get { return _is_top; }
            set { _is_top = value; }
        }
        private bool _is_default;
        /// <summary>
        /// is_default
        /// </summary>	
        public bool is_default
        {
            get { return _is_default; }
            set { _is_default = value; }
        }
    }
}

