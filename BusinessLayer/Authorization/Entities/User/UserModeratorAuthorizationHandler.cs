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
    public class UserModeratorAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, AppUser>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
								   AppUser resource)
        {
            if (requirement.Name != BlogConstants.UpdateOperationName)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole("Moderator"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
