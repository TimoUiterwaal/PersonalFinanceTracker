using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker
{
	public class DashboardController : Controller
	{
		private readonly ApplicationDbContext _context;
		public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			//gather everything you want here, and you can pass the view item to the view
			var blankinput = new DashboardViewItem();
			return View(blankinput);

		}

		[HttpPost]
		public IActionResult Search(DashboardViewItem dashboardsearch)
		{
			dashboardsearch.Receipts = _context.Receipt
				.Include(r => r.Vendor)
				.Where(r => r.TransactionDate.Date == dashboardsearch.InputDate.Date)
				.OrderByDescending(r => r.TransactionDate)
				.AsNoTracking()
				.ToList();

			return View("Index", dashboardsearch);
		}
		
		public IActionResult Details(int id)
		{

			Receipt? receipt = _context.Receipt
			.Include(r => r.Vendor)
			.Include(r => r.Transactions)
			.AsNoTracking()
			.FirstOrDefault(r => r.Id == id);

			if (receipt is null)
			{
				return NotFound();
			}

			return View("Index", new DashboardViewItem
			{
				InputDate = receipt.TransactionDate,
				Receipts = [receipt],
				Transactions = receipt.Transactions
			});
		}
	}
}
