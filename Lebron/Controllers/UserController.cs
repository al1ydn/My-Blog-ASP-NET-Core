using EntityLayer.Concrete;
using Lebron.Models;
using Microsoft.AspNetCore.Authorization;
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
			selectedUser.PasswordHash = _userManager.PasswordHasher.HashPassword(selectedUser, userEditModel.Password);

			var result = await _userManager.UpdateAsync(selectedUser);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Dashboard");
			}

			return View();
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Add(UserAddModel userAddModel)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser();
				appUser.UserName = userAddModel.UserName;

				var result = await _userManager.CreateAsync(appUser, userAddModel.Password);

				if (result.Succeeded)
				{
					return RedirectToAction("SignIn", "UserSignIn");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}

			foreach (var modelState in ViewData.ModelState.Values)
			{
				foreach (var error in modelState.Errors)
				{
					Console.WriteLine(error.ErrorMessage);
				}
			}

			return View(userAddModel);
		}
	}
}
