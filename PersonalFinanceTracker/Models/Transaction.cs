using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker
{
	/// <summary>
	/// A single line item on a receipt. UnitPrice and Quantity are optional —
	/// Total is the authoritative amount, since the unit breakdown is often unknown.
	/// </summary>
	public class Transaction
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Receipt")]
		[Range(1, int.MaxValue, ErrorMessage = "Please select a receipt.")]
		[Display(Name = "Receipt")]
		public int ReceiptId { get; set; }
		public Receipt? Receipt { get; set; }

		[StringLength(100)]
		[Display(Name = "Item")]
		public required string Name { get; set; }

		[Range(typeof(decimal), "0", "1000000",
		ErrorMessage = "Unit price must be between {1} and {2}.",
		ParseLimitsInInvariantCulture = true)]
		[Display(Name = "Unit Price")]
		public decimal? UnitPrice { get; set; }

		[Range(typeof(decimal), "0", "1000000",
		ErrorMessage = "Unit Quantity must be between {1} and {2}.",
		ParseLimitsInInvariantCulture = true)]
		public decimal? Quantity { get; set; }

		[Range(typeof(decimal), "0", "1000000",
		ErrorMessage = "Total must be between {1} and {2}.",
		ParseLimitsInInvariantCulture = true)]
		public decimal Total { get; set; }
	}
}
