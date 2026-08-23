using Microsoft.AspNetCore.Mvc;

namespace PersonalFinanceTracker
{
	public class SystemSetupsController : Controller
	{
		private readonly ApplicationDbContext _context;
		public SystemSetupsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: SystemSetups
		public ActionResult Index()
		{
			SystemSetup? systemSetup = _context.SystemSetup.FirstOrDefault();
			return View(systemSetup);
		}

		// GET: SystemSetups/Edit
		public ActionResult Edit()
		{
			SystemSetup systemSetup = _context.SystemSetup.FirstOrDefault()
				?? new SystemSetup { BasePath = string.Empty };
			return View(systemSetup);
		}

		// POST: SystemSetups/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(SystemSetup systemSetup)
		{
			if (!ModelState.IsValid)
			{
				return View(systemSetup);
			}

			// Id 0 means no row existed yet, so this is the first save.
			if (systemSetup.Id == 0)
			{
				_context.SystemSetup.Add(systemSetup);
			}
			else
			{
				_context.SystemSetup.Update(systemSetup);
			}

			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
