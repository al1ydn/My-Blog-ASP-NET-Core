using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
