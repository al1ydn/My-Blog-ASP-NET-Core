using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
			Writer writer = writerManager.readById(23);

			return View(writer);
		}
		[HttpPost]
		public IActionResult EditProfile(Writer writer)
		{
			writer.Status = true;
			writerManager.update(writer);

			return RedirectToAction("Index", "Dashboard");
		}
	}
}
