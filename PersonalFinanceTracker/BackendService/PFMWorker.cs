using Microsoft.Extensions.Logging;

namespace PersonalFinanceTracker
{
	public class PFMWorker(IServiceScopeFactory scopeFactory, ILogger<PFMWorker> logger) :  BackgroundService
	{
		private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
		private readonly ILogger<PFMWorker> _logger = logger;


		protected override async Task ExecuteAsync(CancellationToken stoppingToken) 
		{
		
			while (!stoppingToken.IsCancellationRequested)
			{
				try
				{
					_logger.LogInformation("Worker running at: {Time}", DateTime.Now);
					using var scope = _scopeFactory.CreateScope();
					var receiptImporter = scope.ServiceProvider.GetRequiredService<ReceiptImporter>();
					var transactionImporter = scope.ServiceProvider.GetRequiredService<TransactionImport>();
					receiptImporter.ProcessImportReceipt();
					transactionImporter.ProcessImportTransaction();

				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Worker error");
				}

				await Task.Delay(1_000, stoppingToken);
			}
			

		}

	}
}
