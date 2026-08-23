namespace PersonalFinanceTracker
{
	public class ImporterWrapper ()
	{
		public static void ProcessImport(ApplicationDbContext _context)
		{
			var importerUtility = new ImporterUtility(_context);
			var receiptImporter = new ReceiptImporter(_context, importerUtility);
			var transactionImporter = new TransactionImport(_context, importerUtility);
			receiptImporter.ProcessImportReceipt();
			transactionImporter.ProcessImportTransaction(); 

			return;
		}
	}
}
