using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EFAboutRepo());

		public IActionResult Index()
		{
			return View(aboutManager.read());
		}

        public PartialViewResult StayConnect()
		{
			return PartialView();
		}
    }
}
