using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class WriterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EFWriterRepo());

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult EditProfile()
		{
			var userName = User.Identity.Name;

			Context context = new Context();
			var writerId = context.Writers.Where(x => x.UserName == userName)
				.Select(x => x.Id)
				.FirstOrDefault();

			Writer writer = writerManager.readById(writerId);
			return View(writer);
		}
		[HttpPost]
		public IActionResult EditProfile(Writer writer)
		{
			writerManager.update(writer);

			return RedirectToAction("Index", "Dashboard");
		}
	}
}
