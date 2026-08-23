using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker
{
	public class ReceiptImporter(ApplicationDbContext _context, ReceiptImporterUtility _receiptImporterUtility)
	{
		public void ProcessImportReceipt()
		{

			//check if directory exists, if not, build
			if (!_receiptImporterUtility.CheckBasePathExists())
			{
				_receiptImporterUtility.BuildBasePathDirectory();
			}

			if (_receiptImporterUtility.CheckBasePathContainsFiles(".csv")){

				foreach (var path in _receiptImporterUtility.GetBasePathFilePaths(".csv"))
				{
					using var stream = File.OpenRead(path);
					ImportReceipt(stream);
				}

			}

		}
		public ReceiptImportResult ImportReceipt(Stream file)
		{
		
			ReceiptImportResult receiptImportResult = new();

			using var reader = new StreamReader(file);

			int i = 0;
			string? line;

			while ((line = reader.ReadLine()) != null)
			{
				string[] csvfields = line.Split(',');
				receiptImportResult.Rowsread++;

				if (csvfields.Count() != 7)
				{
					receiptImportResult.Errorlines.Add((i, "Unexpected Number of Rows"));
				}

				for (int j = 0; j < 7; j++)
				{
					if (csvfields[j].Length == 0 || file is null)
					{
						receiptImportResult.Errorlines.Add((i, $"Empty Value in position {j}"));

					}
				}

				receiptImportResult.RowsImported++;

				var newrow = new ReceiptCsvRow(csvfields);

				var newreceipt = new Receipt();

				//TODO add failure catch
				newreceipt.VendorId = int.Parse(newrow.VendorId);
				newreceipt.PaymentMethod = Enum.Parse<PaymentMethodEnums>(newrow.PaymentMethod);
				newreceipt.ItemCount = int.Parse(newrow.ItemCount);
				newreceipt.SubTotal = decimal.Parse(newrow.Subtotal);
				newreceipt.Tax = decimal.Parse(newrow.Tax);
				newreceipt.Recurring = bool.Parse(newrow.Recurring);
				newreceipt.TransactionDate = DateTime.Parse(newrow.TransactionDate);

				_context.Receipt.Add(newreceipt);
				i++;
			}
			_context.SaveChanges();

			return receiptImportResult;
		}
		
	}
}
