using BusinessLayer.Authorization.AuthorizeAttributes.MinimumAge;
using BusinessLayer.Authorization.AuthorizeAttributes.OnlyAnonymous;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.Customization
{
    public class CustomAuthorizationMiddlewareResultHandler 
        : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler backupHandler = new();

        public async Task HandleAsync(RequestDelegate next,
                                      HttpContext context,
                                      AuthorizationPolicy policy,
                                      PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Forbidden &&
                authorizeResult.AuthorizationFailure!.FailedRequirements
                    .OfType<MinimumAgeRequirement>()
                    .Any())
            {
                context.Response.StatusCode =
                    StatusCodes.Status403Forbidden;

                return;
            }
            else if (authorizeResult.Forbidden &&
                authorizeResult.AuthorizationFailure!.FailedRequirements
                    .OfType<OnlyAnonymousRequirement>()
                    .Any())
            {
                context.Response.Redirect("/Blog");

                return;
            }
            //Forbid
            else if (context.Request.Path.Value == "/Forbidden")
            {
                context.Response.StatusCode =
                    StatusCodes.Status403Forbidden;

                return;
            }
            /*//Challenge
            else if (context.Request.Path.Value == "/Account/Login")
            {
                context.Response.Redirect("/UserSignIn/SignIn" +
                    context.Request.QueryString.Value);

                return;
            }*/

            await backupHandler.HandleAsync(next,
                                            context,
                                            policy,
                                            authorizeResult);
        }
    }
}
