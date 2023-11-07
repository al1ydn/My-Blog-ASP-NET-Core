using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class Message2Controller : Controller
	{
		Message2Manager message2Manager = new Message2Manager(new EFMessage2Repo());

		public IActionResult Index()
		{
			return View(message2Manager.readIncludeWriterByMessage2ReceiverFilter(7));
		}

		public IActionResult Detail(int id)
		{
			return View(message2Manager.readById(id));
		}
	}
}
