using EntityLayer.Concrete;
using Lebron.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	[AllowAnonymous]
	public class Login2Controller : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public Login2Controller(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(Login2Model login2Model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var result = await _signInManager.PasswordSignInAsync(login2Model.UserName, login2Model.Password, false, true);

			if(result.Succeeded)
			{
				return RedirectToAction("Index", "Dashboard");
			}

			return View();
		}
	}
}
