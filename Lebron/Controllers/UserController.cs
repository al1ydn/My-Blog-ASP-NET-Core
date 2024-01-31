using BusinessLayer.Authorization.AuthorizeAttributes.MinimumAge;
using BusinessLayer.Authorization.AuthorizeAttributes.OnlyAnonymous;
using BusinessLayer.Authorization.Entities.Blog;
using BusinessLayer.Authorization.Entities.User;
using BusinessLayer.Concrete;
using BusinessLayer.Services;
using BusinessLayer.Validation.User;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Lebron.Models;
using Lebron.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;

namespace Lebron.Controllers
{
	public class UserController : DI_Base
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IEmailSender _emailSender;
		private IValidator<UserAddModel> _userAddModelValidator;
		private IValidator<UserEditModel> _userEditModelValidator;
		private IValidator<ResendConfirmationEmailViewModel>
			_resendConfirmationEmailViewModelValidator;

		public UserController(SignInManager<AppUser> signInManager, 
			Context context,
			IAuthorizationService authorizationService,
			UserManager<AppUser> userManager,
			IEmailSender emailSender,
			IValidator<UserAddModel> userAddModelValidator,
			IValidator<UserEditModel> userEditModelValidator,
			IValidator<ResendConfirmationEmailViewModel> 
				resendConfirmationEmailViewModelValidator)
			: base(context, authorizationService, userManager)
		{
			_signInManager = signInManager;
			_emailSender = emailSender;
			_userAddModelValidator = userAddModelValidator;
			_userEditModelValidator = userEditModelValidator;
			_resendConfirmationEmailViewModelValidator = resendConfirmationEmailViewModelValidator;
		}

		#region edit
		[HttpGet]
		public async Task<IActionResult> Edit(string userName)
		{
			#region isValid
			if (!ModelState.IsValid)
			{
				return UnprocessableEntity();
			}

			UserEditModel validationModel = new();
			validationModel.UserName = userName;
			ValidationResult validationResult = await _userEditModelValidator
				.ValidateAsync(validationModel, options =>
			{
				options.IncludeProperties(x => x.UserName);
			});

			if (!validationResult.IsValid)
			{
				//validationResult.AddToModelState(this.ModelState);

				//return View();
				//return UnprocessableEntity(ModelState);
				return UnprocessableEntity();
			}
			#endregion

			AppUser selectedUser = await UserManager.FindByNameAsync(userName);
			if (selectedUser == null)
			{
				return NotFound();
			}

			#region isAuthorized
			AuthorizationResult isAuthorized = await AuthorizationService
				.AuthorizeAsync(User, selectedUser, UserOperations.Update);
			if (!isAuthorized.Succeeded)
			{
				return Forbid();
			}
			#endregion

			#region copy to viewmodel
			UserEditModel userEditModel = new UserEditModel();
			userEditModel.Name = selectedUser.Name;
			userEditModel.About = selectedUser.About;
			userEditModel.Image = selectedUser.Image;
			userEditModel.UserName = selectedUser.UserName;
			userEditModel.InitialUserName = selectedUser.UserName;
			userEditModel.Email = selectedUser.Email;
			#endregion

			return View(userEditModel);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(UserEditModel userEditModel)
		{
			#region isValid
			if (!ModelState.IsValid)
			{
				return UnprocessableEntity();
			}

			ValidationResult validationResult =
				await _userEditModelValidator.ValidateAsync(userEditModel);
			if (!validationResult.IsValid)
			{
				validationResult.AddToModelState(this.ModelState);

				return View();
			}
			#endregion

			AppUser selectedUser = 
				await UserManager.FindByNameAsync(userEditModel.InitialUserName);
			if (selectedUser == null)
			{
				return NotFound();
			}

			#region isAuthorized
			AuthorizationResult isAuthorized = await AuthorizationService
				.AuthorizeAsync(User, selectedUser, UserOperations.Update);
			if (!isAuthorized.Succeeded)
			{
				return Forbid();
			}
			#endregion

			#region copy from viewmodel
			selectedUser.Name = userEditModel.Name;
			selectedUser.About = userEditModel.About;
			selectedUser.Image = userEditModel.Image;
			selectedUser.UserName = userEditModel.UserName;
			selectedUser.Email = userEditModel.Email;

			if (userEditModel.Password != null)
			{
				selectedUser.PasswordHash =
					UserManager.PasswordHasher.HashPassword(
						selectedUser,
						userEditModel.Password);
			}
			#endregion

			IdentityResult identityResult = 
				await UserManager.UpdateAsync(selectedUser);
			if (!identityResult.Succeeded)
			{
				ErrorViewModel errorViewModel = new();
				errorViewModel.Description = ErrorDescriptions.Update;
				return View("Error", errorViewModel);
			}

			if (userEditModel.InitialUserName != selectedUser.UserName)
			{
				await _signInManager.RefreshSignInAsync(selectedUser);
			}

			return RedirectToAction("Index", "Dashboard");
		}
		#endregion

		#region add
		[OnlyAnonymous]
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[TempData]
		public string? AddResultMessage { get; set; }

		[OnlyAnonymous]
		[HttpPost]
		public async Task<IActionResult> Add(UserAddModel userAddModel)
		{
			#region isValid
			if (!ModelState.IsValid)
			{
				return View();
			}

			ValidationResult validationResult =
				await _userAddModelValidator.ValidateAsync(userAddModel);
			if (!validationResult.IsValid)
			{
				validationResult.AddToModelState(this.ModelState);

				return View();
			}
			#endregion

			#region create
			AppUser newUser = new AppUser();
			newUser.UserName = userAddModel.UserName;
			newUser.Email = userAddModel.Email;

			IdentityResult createResult = await UserManager
				.CreateAsync(newUser, userAddModel.Password);
			if (!createResult.Succeeded)
			{
				/*string key = "";
				foreach (var error in createResult.Errors)
				{
					if (error.Code.Contains("UserName"))
					{
						key = "UserName";
					}
					if (error.Code.Contains("Email"))
					{
						key = "Email";
					}

					ModelState.AddModelError(key, error.Description);
				}

				return View();*/

				ErrorViewModel errorViewModel = new();
				errorViewModel.Description = ErrorDescriptions.Create;
				return View("Error", errorViewModel);
			}
			AddResultMessage = "Kayit tamamlandi. ";
			#endregion

			#region send email
			string sendResult = await SendConfirmationEmail(newUser);

			if (sendResult == "Hata")
			{
				AddResultMessage +=
					" Ancak " +
					newUser.Email +
					" mail adresinize mail yollanamadi. " +
					"Tekrar mail talep etmeyi deneyin.";
			}
			if (sendResult == "Completed")
			{
				AddResultMessage +=
					newUser.Email +
					" mail adresinizi kontrol ediniz.";
			}
			#endregion

			return RedirectToAction("AddResult");
		}

		[OnlyAnonymous]
		public IActionResult AddResult()
		{
			return View();
		}
		#endregion

		#region confirm email
		public string? EmailConfirmationUrl { get; set; }

		private async Task<string> SendConfirmationEmail(AppUser newUser)
		{
			string token = await UserManager
				.GenerateEmailConfirmationTokenAsync(newUser);
			var encodedBytes = Encoding.UTF8.GetBytes(token);
			string encodedBytesBase64 = 
				WebEncoders.Base64UrlEncode(encodedBytes);

			string newUserId = await UserManager.GetUserIdAsync(newUser);

			#region generate url
			EmailConfirmationUrl = Url.Action(
				"ConfirmEmail",
				"User",
				values: new
				{
					NewUserId = newUserId,
					EncodedBytesBase64 = encodedBytesBase64
				},
				protocol: Request.Scheme
				);
			#endregion


			string newUserEmail = await UserManager.GetEmailAsync(newUser);

			try
			{
				await _emailSender.SendEmailAsync(
					newUserEmail,
					"Lebron - Confirm Your Mail",
					EmailConfirmationUrl);
			}
#pragma warning disable CS0168 // Variable is declared but never used
			catch (Exception exception)
#pragma warning restore CS0168 // Variable is declared but never used
			{
				//log exception.Message;

				return "Hata";
			}

			return "Completed";
		}

		[TempData]
		public string? StatusMessage { get; set; }

		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string NewUserId, string EncodedBytesBase64)
		{
			var encodedBytes = WebEncoders.Base64UrlDecode(EncodedBytesBase64);
			var token = Encoding.UTF8.GetString(encodedBytes);

			var newUser = await UserManager.FindByIdAsync(NewUserId);

			IdentityResult identityResult = await UserManager
				.ConfirmEmailAsync(newUser, token);

			if (identityResult.Succeeded)
			{
				StatusMessage = "Confirmed";
			}
			else
			{
				StatusMessage = "Error";
			}

			return View();
		}

		#region resend
		[AllowAnonymous]
		[HttpGet]
		public IActionResult ResendConfirmationEmail()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> ResendConfirmationEmail(ResendConfirmationEmailViewModel model)
		{
			#region isValid
			if (!ModelState.IsValid)
			{
				return View();
			}

			ValidationResult validationResult =
				await _resendConfirmationEmailViewModelValidator
					.ValidateAsync(model);

			if (!validationResult.IsValid)
			{
				validationResult.AddToModelState(this.ModelState);

				return View();
			}
			#endregion

			AppUser user = await UserManager.FindByEmailAsync(model.Email);

			if (user == null)
			{
				//Message
				return View();
			}

			if (user.EmailConfirmed == true)
			{
				//Message
				return View();
			}

			//Message
			await SendConfirmationEmail(user);

			return View();
		}
		#endregion
		#endregion
	}
}
