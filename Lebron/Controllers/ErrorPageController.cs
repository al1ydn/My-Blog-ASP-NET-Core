using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error1(int code)
		{
			return View();
		}

		public IActionResult Error2(int code)
		{
			return View();
		}
	}
}
