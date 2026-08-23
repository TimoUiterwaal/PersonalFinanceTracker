using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker
{
	public class Vendor
	{
		[Key]
		public int Id { get; set; }
		public required string Name { get; set; }
		public string? Location { get; set; }
		//TODO Enum vendor types
		[Range(1, int.MaxValue, ErrorMessage = "Please select a type.")]
		[Display(Name = "Type")]
		public VendorType Type { get; set; }
	}
}
