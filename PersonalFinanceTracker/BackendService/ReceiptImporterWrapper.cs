namespace PersonalFinanceTracker
{
	public class ReceiptImporterWrapper ()
	{
		public static void StartImport(ApplicationDbContext _context)
		{
			var importerUtility = new ReceiptImporterUtility(_context);
			var receiptImporter = new ReceiptImporter(_context, importerUtility);
			receiptImporter.ProcessImportReceipt();
			return;
		}
	}
}
