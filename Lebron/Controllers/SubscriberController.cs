using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class SubscriberController : Controller
	{
		[HttpGet]
		public PartialViewResult Index()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult Index(Subscriber subsriber)
		{
			return PartialView();
		}
	}
}
