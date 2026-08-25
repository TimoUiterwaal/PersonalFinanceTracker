using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker
{
	public class ReceiptImporter(ApplicationDbContext _context, ImporterUtility _importerUtility, ILogger<TransactionImport> _logger)
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
					
				}
				_importerUtility.RemoveBasePathFiles(".csv", ImportTypes.Receipt);
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
					_logger.LogWarning("Row {Row}: expected 5 fields, got {Count}", receiptImportResult.Rowsread, csvfields.Length);
					receiptImportResult.Errorlines.Add((receiptImportResult.Rowsread, "Unexpected Number of Rows"));
					continue;
				}
				//Could do error check and add to row on the same loop potentially, but for now, we will do a separate loop to check for empty values
				for (int j = 0; j < 7; j++)
				{
					if (csvfields[j].Length == 0)
					{
						_logger.LogWarning("Row {Row}: empty fields in {j}", receiptImportResult.Rowsread, j);

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

				try { 
				newreceipt.VendorId = int.Parse(newrow.VendorId);
				newreceipt.PaymentMethod = Enum.Parse<PaymentMethodEnums>(newrow.PaymentMethod);
				newreceipt.ItemCount = int.Parse(newrow.ItemCount);
				newreceipt.SubTotal = decimal.Parse(newrow.Subtotal);
				newreceipt.Tax = decimal.Parse(newrow.Tax);
				newreceipt.Recurring = _importerUtility.ParseBooleanValue(newrow.Recurring);
				newreceipt.TransactionDate = DateTime.Parse(newrow.TransactionDate);
				}
				catch
				{
					_logger.LogWarning("Row {Row}: Error Importing row", receiptImportResult.Rowsread);
					receiptImportResult.Errorlines.Add((receiptImportResult.Rowsread, $"Error Importing row"));
					continue;
				}

				_context.Receipt.Add(newreceipt);

				_logger.LogInformation("Imported {Imported} of {Read} rows", receiptImportResult.RowsImported, receiptImportResult.Rowsread);
				receiptImportResult.RowsImported++;
			}
			_context.SaveChanges();

			return receiptImportResult;
		}
		
	}
}
