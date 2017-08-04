using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecialLogisticsSystem.Tool;
using System.ComponentModel;

namespace SpecialLogisticsSystem.Model
{
   [DisplayName("编号设置")]
    public class T_Cm_SequenceNumber : Entity
    {
        #region "字段名称"
        /// <summary>
        /// Code
        /// </summary>
        public static string CodeColumnName
        {
            get
            {
                return DynamicPropertyHelper.GetPropertyName<T_Cm_SequenceNumber>(p => p.code);
            }
        }
        private string _name;
        /// <summary>
        /// name
        /// </summary>
        [NoColumn]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        private int _id;
        /// <summary>
        /// id
        /// </summary>
        [PrimaryKey(true)]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _code;
        /// <summary>
        /// code
        /// </summary>
        [PrimaryKey(true)]
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _prefix;
        /// <summary>
        /// 前缀
        /// </summary>
        [PrimaryKey(true)]
        public string prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }
        private string _date_type;
        /// <summary>
        /// 日期类型
        /// </summary>
        [PrimaryKey(true)]
        public string date_type
        {
            get { return _date_type; }
            set { _date_type = value; }
        }
        private string _infix;
        /// <summary>
        /// 中缀
        /// </summary>
        [PrimaryKey(true)]
        public string infix
        {
            get { return _infix; }
            set { _infix = value; }
        }
        private int _index_length;
        /// <summary>
        /// 自增流水号长度
        /// </summary>
        [PrimaryKey(true)]
        public int index_length
        {
            get { return _index_length; }
            set { _index_length = value; }
        }
        private string _suffix;
        /// <summary>
        /// 后缀
        /// </summary>
        [PrimaryKey(true)]
        public string suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }
        private string _max_date;
        /// <summary>
        /// 当前最大日期值
        /// </summary>
        [PrimaryKey(true)]
        public string max_date
        {
            get { return _max_date; }
            set { _max_date = value; }
        }
        private int _max_index;
        /// <summary>
        /// 当前最大流水号值
        /// </summary>
        [PrimaryKey(true)]
        public int max_index
        {
            get { return _max_index; }
            set { _max_index = value; }
        }
        /// <summary>
        /// 
        /// </summary>		
        private string _currentmaxvalue;
        public string CurrentMaxValue
        {
            get { return _currentmaxvalue; }
            set { _currentmaxvalue = value; }
        }
    }
}
