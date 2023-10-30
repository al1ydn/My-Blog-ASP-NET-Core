using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class WriterController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
