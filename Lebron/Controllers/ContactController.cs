using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class ContactController : Controller
	{
		ContactManager contactManager = new ContactManager(new EFContactRepo());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.Date = DateTime.Now;
			contact.Status = true;

			contactManager.create(contact);

			return View();
		}
	}
}
