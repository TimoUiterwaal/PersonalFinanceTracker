namespace PersonalFinanceTracker
{
	public class TransactionCsvRow(string[] input)
	{
		public string ReceiptId { get; set; } = input[0];
		public string Name { get; set; } = input[1];
		public string? UnitPrice { get; set; } = input[2];
		public string? Quantity { get; set; } = input[3];
		public string Total { get; set; } = input[4];
	}
}
