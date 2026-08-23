using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker
{
	public class VendorController : Controller
	{
		private readonly ApplicationDbContext _context;
		public VendorController(ApplicationDbContext context)
		{
			_context = context;
		}
		// GET: Vendor
		public ActionResult Index()
		{
			var vendor = _context.Vendor.ToList();
			return View(vendor);
		}

		// GET: Vendor/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Vendor/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Vendor/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Vendor vendor)
		{
			if (!ModelState.IsValid)
			{
				return View(vendor);
			}
			_context.Add(vendor);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		// GET: Vendor/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Vendor/Edit/5
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

		// GET: Vendor/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Vendor/Delete/5
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
	}
}
