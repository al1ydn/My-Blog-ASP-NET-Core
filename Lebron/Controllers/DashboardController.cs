using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lebron.Controllers
{
	public class DashboardController : Controller
	{
		Context context = new Context();

		public IActionResult Index()
		{
			var userName = User.Identity.Name;
			var writerId = context.Writers.Where(x => x.UserName == userName)
				                          .Select(x => x.Id)
										  .FirstOrDefault();

			ViewBag.BlogCountWeek = context.Blogs.Where(x => (x.Date > DateTime.Now.AddDays(-7)))
				                                 .Where(x => x.WriterId == writerId).Count();
			ViewBag.BlogCountTotal = context.Blogs.Where(x => x.WriterId == writerId).Count();
			ViewBag.dashboardKarmaWriterId = writerId;

			return View();
		}
	}
}
