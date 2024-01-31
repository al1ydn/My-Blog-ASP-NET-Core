using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.Entities.User
{
	public class UserIsOwnerAuthorizationHandler
		: AuthorizationHandler<OperationAuthorizationRequirement, AppUser>
	{
		UserManager<AppUser> _userManager;

		public UserIsOwnerAuthorizationHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		protected override Task
			HandleRequirementAsync(AuthorizationHandlerContext context, 
				OperationAuthorizationRequirement requirement, 
				AppUser resource)
		{
			if (requirement.Name != UserConstants.UpdateOperationName)
			{
				return Task.CompletedTask;
			}

			if (resource.Id.ToString() ==
				_userManager.GetUserId(context.User))
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;
		}
	}
}
