
using IBatisNet.DataMapper;
namespace MyNamespace.Data
{
	/// <summary>
	/// Base class for Helper objects (*Helper). 
	/// Provides shared utility methods.
	/// </summary>
	public abstract class BaseHelper
	{		
		public SqlMapper Mapper ()
		{
			return IBatisNet.DataMapper.Mapper.Instance ();
		}
	}
}