using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.AuthorizeAttributes.OnlyAnonymous
{
    public class OnlyAnonymousHandler
        : AuthorizationHandler<OnlyAnonymousRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
			OnlyAnonymousRequirement requirement)
        {
            if (!context.User.Identity!.IsAuthenticated)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
