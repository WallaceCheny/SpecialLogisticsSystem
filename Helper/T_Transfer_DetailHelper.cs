using System;
using System.Collections;

namespace MyNamespace.Data
{
	/// <summary>
	/// Helper class for TTransferDetail entites
	/// </summary>
	public class TTransferDetailHelper :BaseHelper
	{
		public TTransferDetail Select(int id)
		{
			return (TTransferDetail)Mapper().QueryForObject("Select",id);
		}
		
		public IList SelectAll()
		{
			return Mapper().QueryForList("Select",null);	
		}
		
		public int Insert(TTransferDetail obj)
		{
			int id =Mapper().Insert("Insert", obj);
			
			return id;
		}
		
		public int Update(TTransferDetail obj)
		{
			return Mapper().Update("Update", obj);
		}
		
		public int Delete(int id)
		{
			return Mapper().Delete("Delete", id);
		}		

	}
}