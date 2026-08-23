namespace PersonalFinanceTracker
{
	public class TransactionImport(ApplicationDbContext _context, ImporterUtility _importerUtility)
	{
		public void ProcessImportTransaction()
		{
			//check if directory exists, if not, build
			if (!_importerUtility.CheckBasePathExists(ImportTypes.Transaction))
			{
				_importerUtility.BuildBasePathDirectory(ImportTypes.Transaction);
			}

			if (_importerUtility.CheckBasePathContainsFiles(".csv", ImportTypes.Transaction)){

				foreach (var path in _importerUtility.GetBasePathFilePaths(".csv", ImportTypes.Transaction))
				{
					using var stream = File.OpenRead(path);
					ImportTransaction(stream);
					_importerUtility.RemoveBasePathFiles(".csv", ImportTypes.Transaction);
				}
			}
		}
		//could pass file mapping format here to allow for different formats, but for now, we will assume a single format
		public void ImportTransaction(Stream file)
		{
			TransactionImportResult transactionImportResult = new();
			using var reader = new StreamReader(file);
			string? line;

			while ((line = reader.ReadLine()) != null)
			{
				string[] csvfields = line.Split(',');
				transactionImportResult.Rowsread++;
				int rowerror = 0;

				if (csvfields.Length != 5)
				{
					transactionImportResult.Errorlines.Add((transactionImportResult.Rowsread, "Unexpected Number of Rows"));
					continue;
				}

				var newrow = new TransactionCsvRow(csvfields);

				//TODO add failure catch using Try parse and add to error lines if fails, for now, we will assume all data is valid
				var newtransaction = new Transaction() { Name = newrow.Name };

				if (!_context.Receipt.Any(r => r.Id == int.Parse(newrow.ReceiptId)))
				{
					transactionImportResult.Errorlines.Add((transactionImportResult.Rowsread, $"ReceiptId {newrow.ReceiptId} does not exist in database"));
					continue;
				}
				newtransaction.ReceiptId = int.Parse(newrow.ReceiptId);
				//Using Ternary operator to check if the value can be parsed as this is an optional value, if not, set to null
				newtransaction.UnitPrice = decimal.TryParse(newrow.UnitPrice, out decimal unitPrice) ? unitPrice : null;
				newtransaction.Quantity = decimal.TryParse(newrow.Quantity, out decimal quantity) ? quantity : null;
				if(newtransaction.UnitPrice != null && newtransaction.Quantity != null)
				{
					newtransaction.Total = (decimal)(newtransaction.UnitPrice * newtransaction.Quantity);
				}
				else { newtransaction.Total = decimal.TryParse(newrow.Total, out decimal total) ? total : 0; }
				
				_context.Transaction.Add(newtransaction);
				transactionImportResult.RowsImported++;
			}
			_context.SaveChanges();
		}

	}
	}
