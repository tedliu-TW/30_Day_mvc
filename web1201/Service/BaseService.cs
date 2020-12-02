using System.Configuration;

namespace web1201.Service
{
	public abstract class BaseService
	{
		protected readonly string cnstr;
		protected  abstract string tableName { get; }

		public BaseService()
		{
			cnstr = ConfigurationManager.ConnectionStrings["MVC"].ConnectionString;
		}
	}
}