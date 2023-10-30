using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lebron.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		//[HttpPost]
		//[AllowAnonymous]
		//public IActionResult Index(Writer writer)
		//{
		//	Context context = new Context();

		//	var isMatched = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail
		//													 && x.Password == writer.Password);

		//	if (isMatched != null)
		//	{
		//		HttpContext.Session.SetString("username", writer.Mail);

		//		return RedirectToAction("Index", "Blog");
		//	}
		//	else
		//	{
		//		return View();
		//	}
		//}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(Writer writer)
		{
			Context context = new Context();

			var isMatched = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail
															 && x.Password == writer.Password);

			if (isMatched != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, writer.Mail)
				};
				var userIdentity = new ClaimsIdentity(claims, "a");
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(claimsPrincipal);

				return RedirectToAction("Index", "Blog");
			}
			else
			{
				return View();
			}
		}
	}
}
