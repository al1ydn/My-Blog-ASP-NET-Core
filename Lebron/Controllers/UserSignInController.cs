using BusinessLayer.Authorization.AuthorizeAttributes.MinimumAge;
using BusinessLayer.Authorization.AuthorizeAttributes.OnlyAnonymous;
using BusinessLayer.Validation.User;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lebron.Controllers
{
	public class UserSignInController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private IValidator<UserSignInModel> _userSignInModelValidator;

		public UserSignInController(SignInManager<AppUser> signInManager,
			IValidator<UserSignInModel> userSignInModelValidator)
		{
			_signInManager = signInManager;
			_userSignInModelValidator = userSignInModelValidator;
		}

		#region SignIn
		[OnlyAnonymous]
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}

		[OnlyAnonymous]
		[HttpPost]
		public async Task<IActionResult> SignIn(
			UserSignInModel userSignInModel,
			string? ReturnUrl)
		{
			#region isValid
			if (!ModelState.IsValid)
			{
				return View();
			}

			ValidationResult validationResult =
				await _userSignInModelValidator.ValidateAsync(userSignInModel);

			if (!validationResult.IsValid)
			{
				validationResult.AddToModelState(this.ModelState);

				return View();
			}
			#endregion

			var result = await _signInManager.PasswordSignInAsync(
				userSignInModel.UserName,
				userSignInModel.Password,
				userSignInModel.RememberMe,
				true);

			/*//SignInWithClaimsAsync
			#region verify credentials
			AppUser user = await _signInManager.UserManager
					.FindByNameAsync(userSignInModel.UserName);
			var result2 = await _signInManager.CheckPasswordSignInAsync(
				user,
				userSignInModel.Password,
				true);

			if (!result2.Succeeded)
			{
				return View();
			}
			#endregion

			#region add claims
			CustomClaims userCustomClaims = new(user);

			List<Claim> customClaims = new List<Claim>
			{
				userCustomClaims.GetBirthdate(),
			};
			#endregion

			await _signInManager.SignInWithClaimsAsync(
				user,
				userSignInModel.RememberMe,
				customClaims);*/

			/*ClaimsIdentity identity = new ClaimsIdentity(claims, "Test");

			ClaimsPrincipal principal = new ClaimsPrincipal(identity);

			await HttpContext.SignInAsync("Test", principal);
			await HttpContext.SignOutAsync("Test");*/

			/*if (result.IsLockedOut)
			{
				// Redirect to lockedout page
			}

			if (result.IsNotAllowed)
			{
				// Redirect to notallowed page
			}*/

			if (result.Succeeded)
			{
				if (ReturnUrl != null)
				{
					return LocalRedirect(ReturnUrl);
				}
				else
				{
					return RedirectToAction("Index", "Blog");
				}
			}

			return View();
		}
		#endregion

		public async Task<IActionResult> UserSignOut(
			string? ReturnUrlOut)
		{
			await _signInManager.SignOutAsync();

			if (ReturnUrlOut != null)
			{
				return LocalRedirect(ReturnUrlOut);
			}
			else
			{
				return RedirectToAction("Index", "Blog");
			}
		}
	}
}
