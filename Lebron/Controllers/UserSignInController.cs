using EntityLayer.Concrete;
using Lebron.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	[AllowAnonymous]
	public class UserSignInController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public UserSignInController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(UserAddModel userAddModel)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var result = await _signInManager.PasswordSignInAsync(userAddModel.UserName, userAddModel.Password, false, true);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Dashboard");
			}

			return View();
		}

		public async Task<IActionResult> UserSignOut()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Index", "Blog");
		}
	}
}
