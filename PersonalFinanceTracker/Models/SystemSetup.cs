using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker
{
	public class SystemSetup
	{
		[Key]
		public int Id { get; set; }
		public required string BasePath {get; set;}
	}
}
