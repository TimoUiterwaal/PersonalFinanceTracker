namespace PersonalFinanceTracker
{
	public class ReceiptImportResult
	{
		public int Rowsread { get; set; }
		public int RowsImported { get; set; }
		public List<int>? CreatedReceiptIds { get; set; }
		public List<(int linenum, string errormessage)>? Errorlines { get; set; } = new();

	}
}
