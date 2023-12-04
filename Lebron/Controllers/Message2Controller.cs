using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Lebron.Controllers
{
	public class Message2Controller : Controller
	{
		Message2Manager message2Manager = new Message2Manager(new EFMessage2Repo());

		private readonly UserManager<AppUser> _userManager;
		public Message2Controller(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Inbox()
		{
			var userId = int.Parse(_userManager.GetUserId(User));

			return View(message2Manager.readIncludeUserByMessage2ReceiverFilter(userId));
		}

		public IActionResult Detail(int id)
		{
			return View(message2Manager.readById(id));
		}

		public bool? EditIsRead(int id)
		{
			var selectedMessage = message2Manager.readById(id);
			selectedMessage.isRead = !selectedMessage.isRead;
			message2Manager.update(selectedMessage);

			return selectedMessage.isRead;
		}

		public void EditIsReadAsRead(int id)
		{
			var selectedMessage = message2Manager.readById(id);
			selectedMessage.isRead = true;
			message2Manager.update(selectedMessage);
		}

		public IActionResult Sendbox()
		{
			var userId = int.Parse(_userManager.GetUserId(User));

			return View(message2Manager.readIncludeUserByMessage2SenderFilter(userId));
		}
	}
}
