namespace PersonalFinanceTracker
{
	public class ReceiptCsvRow(string[] input)
	{
		public string VendorId { get; set; } = input[0];
		public string PaymentMethod { get; set; } = input[1];
		public string ItemCount { get; set; } = input[2];
		public string Subtotal { get; set; } = input[3];
		public string Tax { get; set; } = input[4];
		public string Recurring { get; set; } = input[5];
		public string TransactionDate { get; set; } = input[6];
	}
}
