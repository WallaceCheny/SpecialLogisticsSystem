using System;
using System.Collections;

namespace MyNamespace.Data
{
	/// <summary>
	/// Helper class for TCmBranch entites
	/// </summary>
	public class TCmBranchHelper :BaseHelper
	{
		public TCmBranch Select(int id)
		{
			return (TCmBranch)Mapper().QueryForObject("Select",id);
		}
		
		public IList SelectAll()
		{
			return Mapper().QueryForList("Select",null);	
		}
		
		public int Insert(TCmBranch obj)
		{
			int id =Mapper().Insert("Insert", obj);
			
			return id;
		}
		
		public int Update(TCmBranch obj)
		{
			return Mapper().Update("Update", obj);
		}
		
		public int Delete(int id)
		{
			return Mapper().Delete("Delete", id);
		}		

	}
}