using System;
using System.Collections;

namespace MyNamespace.Data
{
	/// <summary>
	/// Helper class for TCmCarArea entites
	/// </summary>
	public class TCmCarAreaHelper :BaseHelper
	{
		public TCmCarArea Select(int id)
		{
			return (TCmCarArea)Mapper().QueryForObject("Select",id);
		}
		
		public IList SelectAll()
		{
			return Mapper().QueryForList("Select",null);	
		}
		
		public int Insert(TCmCarArea obj)
		{
			int id =Mapper().Insert("Insert", obj);
			
			return id;
		}
		
		public int Update(TCmCarArea obj)
		{
			return Mapper().Update("Update", obj);
		}
		
		public int Delete(int id)
		{
			return Mapper().Delete("Delete", id);
		}		

	}
}