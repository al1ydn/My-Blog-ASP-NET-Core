using Lebron.Models;
using Lebron.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	[AllowAnonymous]
	public class StatusCodePagesController : Controller
	{
		public IActionResult Index(int? statusCode)
		{
			ErrorViewModel errorViewModel = new ErrorViewModel();

			if(statusCode == null)
			{
				return View("Error", errorViewModel);
			}
			errorViewModel.StatusCode = statusCode;

			if (statusCode == StatusCodes.Status404NotFound)
			{
				errorViewModel.Description = 
					ErrorDescriptions.Status404NotFound;
			}
			else if (statusCode == StatusCodes.Status422UnprocessableEntity)
			{
				errorViewModel.Description = 
					ErrorDescriptions.Status422UnprocessableEntity;
			}
			else if (statusCode == StatusCodes.Status401Unauthorized)
			{
				errorViewModel.Description = 
					ErrorDescriptions.Status401Unauthorized;
			}
			else if (statusCode == StatusCodes.Status403Forbidden)
			{
				errorViewModel.Description = 
					ErrorDescriptions.Status403Forbidden;
			}

			return View("Error", errorViewModel);
		}
	}
}
