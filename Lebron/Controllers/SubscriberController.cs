using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class SubscriberController : Controller
	{
		SubscriberManager subscriberManager = new SubscriberManager(new EFSubscriberRepo());

		[HttpGet]
		public PartialViewResult Index()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult Index(Subscriber subscriber)
		{
			subscriber.Status = true;

			subscriberManager.create(subscriber);

			return PartialView();
		}
	}
}
