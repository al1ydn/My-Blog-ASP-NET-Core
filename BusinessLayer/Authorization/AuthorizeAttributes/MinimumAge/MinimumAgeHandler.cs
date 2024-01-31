using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.AuthorizeAttributes.MinimumAge
{
    public class MinimumAgeHandler
        : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            MinimumAgeRequirement requirement)
        {
            Claim? age = context.User.Claims
                .FirstOrDefault(x => x.Type == "Age");

            if (age == null)
            {
                return Task.CompletedTask;
            }

            if (age.Value == "Unspecified")
            {
                return Task.CompletedTask;
            }

            if (!int.TryParse(age.Value, out int ageInt))
            {
                return Task.CompletedTask;
            }

            if (ageInt > requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
