using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
