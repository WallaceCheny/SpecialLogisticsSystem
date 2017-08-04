using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace SpecialLogisticsSystem.Model{
	 	//打印模版信息
    public class T_Cm_Template : Entity
	{
   		     
      	/// <summary>
		/// id
        /// </summary>		
		private Guid _id;
          [PrimaryKey(true)]
        public Guid id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 模版名称
        /// </summary>		
		private string _template_name;
        public string template_name
        {
            get{ return _template_name; }
            set{ _template_name = value; }
        }        
		/// <summary>
		/// 模版类型
        /// </summary>		
		private string _template_type;
        public string template_type
        {
            get{ return _template_type; }
            set{ _template_type = value; }
        }        
		/// <summary>
		/// 是否使用
        /// </summary>		
		private bool _is_used;
        public bool is_used
        {
            get{ return _is_used; }
            set{ _is_used = value; }
        }        
		/// <summary>
		/// 系统模版
        /// </summary>		
		private bool _is_system;
        public bool is_system
        {
            get{ return _is_system; }
            set{ _is_system = value; }
        }        
		/// <summary>
		/// 模版宽度
        /// </summary>		
		private decimal _template_width;
        public decimal template_width
        {
            get{ return _template_width; }
            set{ _template_width = value; }
        }        
		/// <summary>
		/// 模版高度
        /// </summary>		
		private decimal _template_height;
        public decimal template_height
        {
            get{ return _template_height; }
            set{ _template_height = value; }
        }        
		/// <summary>
		/// 模版内容
        /// </summary>		
		private string _template_content;
        public string template_content
        {
            get{ return _template_content; }
            set{ _template_content = value; }
        }        
		   
	}
}

