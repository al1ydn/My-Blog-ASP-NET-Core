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
			ViewBag.BlogCountYours = context.Blogs.Where(x => x.WriterId == 9).Count();
			ViewBag.BlogCountWeek = context.Blogs.Where(x => (x.Date > DateTime.Now.AddDays(-7))).Count();
			ViewBag.dashboardKarmaWriterId = 9;

			return View();
		}
	}
}
