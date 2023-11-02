using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class NotificationController : Controller
	{
		NotificationManager notificationManager = new NotificationManager(new EFNotificationRepo());

		public IActionResult Index()
		{
			return View(notificationManager.read());
		}
	}
}
