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

namespace BusinessLayer.Authorization.Entities.Blog
{
    public class BlogIsOwnerAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, EntityLayer.Concrete.Blog>
    {
        UserManager<AppUser> _userManager;

        public BlogIsOwnerAuthorizationHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
								   EntityLayer.Concrete.Blog resource)
        {
            if (requirement.Name != BlogConstants.CreateOperationName &&
                requirement.Name != BlogConstants.DeleteOperationName &&
                requirement.Name != BlogConstants.UpdateOperationName)
            {
                return Task.CompletedTask;
            }

            if (resource.AppUserId.ToString() == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
