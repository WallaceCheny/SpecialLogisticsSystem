using System;
using System.Collections;

namespace MyNamespace.Data
{
	/// <summary>
	/// Helper class for TCmConfig entites
	/// </summary>
	public class TCmConfigHelper :BaseHelper
	{
		public TCmConfig Select(int id)
		{
			return (TCmConfig)Mapper().QueryForObject("Select",id);
		}
		
		public IList SelectAll()
		{
			return Mapper().QueryForList("Select",null);	
		}
		
		public int Insert(TCmConfig obj)
		{
			int id =Mapper().Insert("Insert", obj);
			
			return id;
		}
		
		public int Update(TCmConfig obj)
		{
			return Mapper().Update("Update", obj);
		}
		
		public int Delete(int id)
		{
			return Mapper().Delete("Delete", id);
		}		

	}
}