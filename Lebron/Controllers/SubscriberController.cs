using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lebron.Controllers
{
	[AllowAnonymous]
	public class SubscriberController : Controller
	{
		public IActionResult Add(String mail)
		{
			Subscriber subscriber = new Subscriber();
			subscriber.Mail = mail;
			subscriber.Status = true;

			SubscriberManager subscriberManager = new SubscriberManager(new EFSubscriberRepo());
			subscriberManager.create(subscriber);

			return NoContent();
		}
	}
}
