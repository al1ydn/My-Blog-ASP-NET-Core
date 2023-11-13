using EntityLayer.Concrete;
using Lebron.Areas.Admin.Models;
using Lebron.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	[AllowAnonymous]
	public class Register2Controller : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public Register2Controller(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> Index(Register2Model register2Model)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					UserName = register2Model.UserName, // required for identity
					Name = register2Model.Name,
				};
				var result = await _userManager.CreateAsync(appUser, register2Model.Password);
				
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login2");
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

			return View(register2Model);
		}
	}
}
