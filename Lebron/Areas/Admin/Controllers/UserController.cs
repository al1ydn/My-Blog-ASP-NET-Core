using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<IActionResult> Read()
		{
			List<AppUser> users = _userManager.Users.ToList();
			List<AppUser> writers = new List<AppUser>();
			IList<string> role = new List<string>();

			foreach (var user in users)
			{
				role = await _userManager.GetRolesAsync(user);

				if (role.Any())
				{
					if (role[0] == "Writer")
					{
						writers.Add(user);
					}
				}
			}

			return View(writers);
		}
	}
}
