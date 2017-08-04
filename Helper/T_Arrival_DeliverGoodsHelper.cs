using System;
using System.Collections;

namespace MyNamespace.Data
{
	/// <summary>
	/// Helper class for TArrivalDeliverGood entites
	/// </summary>
	public class TArrivalDeliverGoodHelper :BaseHelper
	{
		public TArrivalDeliverGood Select(int id)
		{
			return (TArrivalDeliverGood)Mapper().QueryForObject("Select",id);
		}
		
		public IList SelectAll()
		{
			return Mapper().QueryForList("Select",null);	
		}
		
		public int Insert(TArrivalDeliverGood obj)
		{
			int id =Mapper().Insert("Insert", obj);
			
			return id;
		}
		
		public int Update(TArrivalDeliverGood obj)
		{
			return Mapper().Update("Update", obj);
		}
		
		public int Delete(int id)
		{
			return Mapper().Delete("Delete", id);
		}		

	}
}