using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker
{
	public class ReceiptImporter(ApplicationDbContext _context, ImporterUtility _importerUtility)
	{
		public void ProcessImportReceipt()
		{
				
			//check if directory exists, if not, build
			if (!_importerUtility.CheckBasePathExists(ImportTypes.Receipt))
			{
				_importerUtility.BuildBasePathDirectory(ImportTypes.Receipt);
			}

			if (_importerUtility.CheckBasePathContainsFiles(".csv", ImportTypes.Receipt)){

				foreach (var path in _importerUtility.GetBasePathFilePaths(".csv", ImportTypes.Receipt))
				{
					using var stream = File.OpenRead(path);
					ImportReceipt(stream);
					_importerUtility.RemoveBasePathFiles(".csv", ImportTypes.Receipt);
				}

			}

		}
		//could pass file mapping format here to allow for different formats, but for now, we will assume a single format
		public ReceiptImportResult ImportReceipt(Stream file)
		{
		
			ReceiptImportResult receiptImportResult = new();

			using var reader = new StreamReader(file);
			string? line;

			while ((line = reader.ReadLine()) != null)
			{
				string[] csvfields = line.Split(',');
				receiptImportResult.Rowsread++;
				int rowerror = 0;

				if (csvfields.Length != 7)
				{
					receiptImportResult.Errorlines.Add((receiptImportResult.Rowsread, "Unexpected Number of Rows"));
					continue;
				}
				//Could do error check and add to row on the same loop potentially, but for now, we will do a separate loop to check for empty values
				for (int j = 0; j < 7; j++)
				{
					if (csvfields[j].Length == 0)
					{
						receiptImportResult.Errorlines.Add((receiptImportResult.Rowsread, $"Empty Value in position {j}"));
						rowerror++;
					}
				}

				if (rowerror > 0)
				{
					continue;
				}


				var newrow = new ReceiptCsvRow(csvfields);

				var newreceipt = new Receipt();

				//TODO add failure catch using Try parse and add to error lines if fails, for now, we will assume all data is valid
				newreceipt.VendorId = int.Parse(newrow.VendorId);
				newreceipt.PaymentMethod = Enum.Parse<PaymentMethodEnums>(newrow.PaymentMethod);
				newreceipt.ItemCount = int.Parse(newrow.ItemCount);
				newreceipt.SubTotal = decimal.Parse(newrow.Subtotal);
				newreceipt.Tax = decimal.Parse(newrow.Tax);
				newreceipt.Recurring = bool.Parse(newrow.Recurring);
				newreceipt.TransactionDate = DateTime.Parse(newrow.TransactionDate);

				_context.Receipt.Add(newreceipt);
				
				receiptImportResult.RowsImported++;
			}
			_context.SaveChanges();

			return receiptImportResult;
		}
		
	}
}
