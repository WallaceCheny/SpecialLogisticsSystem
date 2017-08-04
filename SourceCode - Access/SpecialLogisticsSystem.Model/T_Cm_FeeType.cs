using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
namespace SpecialLogisticsSystem.Model{
	 	//费用类别
     [DisplayName("费用类别")]
    public class T_Cm_FeeType : Entity
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
		/// 费用名称
        /// </summary>		
		private string _fee_name;
        public string fee_name
        {
            get{ return _fee_name; }
            set{ _fee_name = value; }
        }        
		/// <summary>
		/// 单位
        /// </summary>		
		private string _fee_unit;
        public string fee_unit
        {
            get{ return _fee_unit; }
            set{ _fee_unit = value; }
        }        
		/// <summary>
		/// 支出/收入
        /// </summary>		
		private string _fee_type;
        public string fee_type
        {
            get{ return _fee_type; }
            set{ _fee_type = value; }
        }        
		/// <summary>
		/// 顺序
        /// </summary>		
		private int _fee_sort;
        public int fee_sort
        {
            get{ return _fee_sort; }
            set{ _fee_sort = value; }
        }        
		/// <summary>
		/// 默认金额
        /// </summary>		
		private decimal _fee_amount;
        public decimal fee_amount
        {
            get{ return _fee_amount; }
            set{ _fee_amount = value; }
        }        
		/// <summary>
		/// 备注
        /// </summary>		
		private string _fee_note;
        public string fee_note
        {
            get{ return _fee_note; }
            set{ _fee_note = value; }
        }        
		   
	}
}

