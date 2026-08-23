using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker
{
	public class TransactionController : Controller
	{
		private readonly ApplicationDbContext _context;
		public TransactionController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Transaction
		public ActionResult Index()
		{
			var transactions = _context.Transaction
				.Include(t => t.Receipt)
				.ThenInclude(r => r!.Vendor)
				.ToList();
			return View(transactions);
		}

		// GET: Transaction/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Transaction/Create
		public ActionResult Create()
		{
			ViewBag.Receipts = GetReceiptOptions();
			return View(new Transaction { Name = string.Empty, Quantity = 1 });
		}

		// POST: Transaction/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Transaction transaction)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Receipts = GetReceiptOptions();
				return View(transaction);
			}
			_context.Add(transaction);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		// GET: Transaction/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Transaction/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: Transaction/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Transaction/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		private List<SelectListItem> GetReceiptOptions() =>
			_context.Receipt
				.OrderByDescending(r => r.TransactionDate)
				.Select(r => new { r.Id, VendorName = r.Vendor!.Name, r.TransactionDate, r.SubTotal, r.Tax })
				.AsEnumerable()
				.Select(r => new SelectListItem
				{
					Value = r.Id.ToString(),
					Text = $"#{r.Id} - {r.VendorName} - {r.TransactionDate:MMM d, yyyy} - ${r.SubTotal + r.Tax}"
				}).ToList();
	}
}
