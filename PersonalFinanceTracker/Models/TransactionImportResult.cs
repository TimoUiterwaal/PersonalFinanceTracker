namespace PersonalFinanceTracker
{
	public class TransactionImportResult
	{
		public int Rowsread { get; set; }
		public int RowsImported { get; set; }
		public List<int> CreatedTransactionIds { get;} = new();
		public List<(int linenum, string errormessage)> Errorlines { get;} = new();
	}
}
