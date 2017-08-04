using System;
using System.Collections;

namespace MyNamespace.Data
{
	/// <summary>
	/// Helper class for TCmRoleMenuRelation entites
	/// </summary>
	public class TCmRoleMenuRelationHelper :BaseHelper
	{
		public TCmRoleMenuRelation Select(int id)
		{
			return (TCmRoleMenuRelation)Mapper().QueryForObject("Select",id);
		}
		
		public IList SelectAll()
		{
			return Mapper().QueryForList("Select",null);	
		}
		
		public int Insert(TCmRoleMenuRelation obj)
		{
			int id =Mapper().Insert("Insert", obj);
			
			return id;
		}
		
		public int Update(TCmRoleMenuRelation obj)
		{
			return Mapper().Update("Update", obj);
		}
		
		public int Delete(int id)
		{
			return Mapper().Delete("Delete", id);
		}		

	}
}