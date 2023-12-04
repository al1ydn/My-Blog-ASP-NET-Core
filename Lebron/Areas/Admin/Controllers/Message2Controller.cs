using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class Message2Controller : Controller
	{
		public IActionResult Inbox()
		{
			Message2Manager message2Manager = new Message2Manager(new EFMessage2Repo());
			List<Message2> receivedMessages = message2Manager.readIncludeUserByMessage2ReceiverFilter(10);

			return View(receivedMessages);
		}

		public IActionResult Sendbox()
		{
			Message2Manager message2Manager = new Message2Manager(new EFMessage2Repo());
			List<Message2> sendMessages = message2Manager.readIncludeUserByMessage2SenderFilter(10);

			return View(sendMessages);
		}
	}
}
