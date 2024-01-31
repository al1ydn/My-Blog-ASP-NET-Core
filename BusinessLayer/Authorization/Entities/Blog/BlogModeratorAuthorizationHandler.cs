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
    public class BlogModeratorAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, EntityLayer.Concrete.Blog>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
								   EntityLayer.Concrete.Blog resource)
        {
            if (requirement.Name != BlogConstants.DeleteOperationName)
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
