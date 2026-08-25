using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker
{
	public class ReceiptController : Controller
	{
		private readonly ApplicationDbContext _context;
		public ReceiptController(ApplicationDbContext context)
		{
			_context = context;
		}


		// GET: Receipt
		public ActionResult Index()
		{
			var Receipts = _context.Receipt.Include(r => r.Vendor).ToList();
			return View(Receipts);
		}

		// GET: Receipt/Details/5
		public ActionResult Details(int id)
		{
			var receipt = new Receipt();

			try
			{
				receipt = _context.Receipt.FirstOrDefault(x => id == x.Id);

				if (receipt is null)
					return NotFound();

				receipt.Vendor = _context.Vendor.FirstOrDefault(x => receipt.VendorId == x.Id);
				receipt.Transactions = _context.Transaction.Where(x => receipt.Id == x.ReceiptId).ToList();

			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel { RequestId = ex.Message });
			}

			return View(receipt);
		}

		// GET: Receipt/Create
		public ActionResult Create()
		{
			ViewBag.Vendors = GetVendorOptions();
			return View(new Receipt
			{
				TransactionDate = DateTime.Today,
				ItemCount = 1,
				PaymentMethod = PaymentMethodEnums.CreditCard
			});
		}

		// POST: Receipt/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Receipt receipt)
		{
			

			if (!ModelState.IsValid)
			{
				ViewBag.Vendors = GetVendorOptions();
				return View(receipt);
			}

			receipt.InputDate = DateTime.Today;

			_context.Add(receipt);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		// GET: Receipt/Edit/5
		public ActionResult Edit(int id)
		{

			Receipt receipt = new();
			receipt = _context.Receipt.FirstOrDefault(x => id == x.Id);

			ViewBag.Vendors = GetVendorOptions();

			return View(receipt);
		}

		// POST: Receipt/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Receipt receipt)
		{
			Receipt dbreceipt = new();
			dbreceipt = _context.Receipt.FirstOrDefault(x => id == x.Id);

			_context.Entry(dbreceipt).CurrentValues.SetValues(receipt);

			try
			{
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: Receipt/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Receipt/Delete/5
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

		// GET: Receipt/Upload
		[HttpGet]
		public ActionResult Upload()
		{
				return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Upload(IFormFile file){ return View("ReceiptImportResult", ProcessReceipt(file)); }

		private List<SelectListItem> GetVendorOptions() =>
		_context.Vendor
		.OrderBy(v => v.Name)
		.Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name })
		.ToList();

		private ReceiptImportResult ProcessReceipt(IFormFile file)
		{
			using var stream = file.OpenReadStream();
			var importerutility = new ImporterUtility(_context);
			var result = new ReceiptImporter(_context, importerutility).ImportReceipt(stream);

			return result;
		}
	}
}
