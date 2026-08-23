using Microsoft.Extensions.Logging;

namespace PersonalFinanceTracker
{
	public class PFMWorker(IServiceScopeFactory scopeFactory) :  BackgroundService
	{
		private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

		protected override async Task ExecuteAsync(CancellationToken stoppingToken) 
		{
		
			while (!stoppingToken.IsCancellationRequested)
			{
				try
				{
					Console.WriteLine($"Worker running at: {DateTime.Now}" );
					using var scope = _scopeFactory.CreateScope();
					var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

					ReceiptImporterWrapper.StartImport(_context);

				}
				catch (Exception ex)
				{
					Console.WriteLine($"Worker error at: {ex}");
				}

				await Task.Delay(1_000, stoppingToken);
			}
			

		}

	}
}
