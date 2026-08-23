using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker
{
	public class Receipt
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Vendor")]
		[Range(1, int.MaxValue, ErrorMessage = "Please select a vendor.")]
		[Display(Name = "vendor")]
		public int VendorId { get; set; }
		public Vendor? Vendor { get; set; }
		public PaymentMethodEnums PaymentMethod { get; set; }
		public int ItemCount { get; set; }
		[Range(typeof(decimal), "0.01", "1000000",
		ErrorMessage = "Subtotal must be between {1} and {2}.",
		ParseLimitsInInvariantCulture = true)]
		public decimal SubTotal { get; set; }
		[Range(typeof(decimal), "0", "1000000",
		ErrorMessage = "Tax must be between {1} and {2}.",
		ParseLimitsInInvariantCulture = true)]
		public decimal Tax { get; set; }
		public bool Recurring { get; set; }
		[DataType(DataType.Date)]
		[Range(typeof(DateTime), "2010-01-01", "2100-01-01",
		ErrorMessage = "Transaction date must be 2010 or later.",
		ParseLimitsInInvariantCulture = true)]
		public DateTime TransactionDate { get; set; }
		[DataType(DataType.Date)]
		public DateTime InputDate { get; set; } = DateTime.Today;
		public List<Transaction> Transactions { get; set; } = [];

	}
}
