using System;
using System.Collections;

namespace MyNamespace.Data
{
	/// <summary>
	/// Helper class for TCmFeeType entites
	/// </summary>
	public class TCmFeeTypeHelper :BaseHelper
	{
		public TCmFeeType Select(int id)
		{
			return (TCmFeeType)Mapper().QueryForObject("Select",id);
		}
		
		public IList SelectAll()
		{
			return Mapper().QueryForList("Select",null);	
		}
		
		public int Insert(TCmFeeType obj)
		{
			int id =Mapper().Insert("Insert", obj);
			
			return id;
		}
		
		public int Update(TCmFeeType obj)
		{
			return Mapper().Update("Update", obj);
		}
		
		public int Delete(int id)
		{
			return Mapper().Delete("Delete", id);
		}		

	}
}