using EntityLayer.Concrete;
using Lebron.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		public UserController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			var userName = User.Identity.Name;
			var selectedUser = await _userManager.FindByNameAsync(userName);

			UserEditModel userEditModel = new UserEditModel();
			userEditModel.Name = selectedUser.Name;
			userEditModel.About = selectedUser.About;
			userEditModel.Image = selectedUser.Image;
			userEditModel.UserName = selectedUser.UserName;
			userEditModel.Email = selectedUser.Email;

			return View(userEditModel);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(UserEditModel userEditModel)
		{
			var selectedUser = await _userManager.FindByNameAsync(User.Identity.Name);

			selectedUser.Name = userEditModel.Name;
			selectedUser.About = userEditModel.About;
			selectedUser.Image = userEditModel.Image;
			selectedUser.UserName = userEditModel.UserName; // Değişirse tekrar giriş yapmak gerekiyor.
			selectedUser.Email = userEditModel.Email;

			var result = await _userManager.UpdateAsync(selectedUser);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Dashboard");
			}

			return View();
		}
	}
}
