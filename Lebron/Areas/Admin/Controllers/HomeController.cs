using Microsoft.AspNetCore.Mvc;

namespace Lebron.Areas.Admin.Controllers
{
	public class HomeController : Controller
	{
		[Area("Admin")]
		public IActionResult Deneme()
		{
			return View();
		}
	}
}
