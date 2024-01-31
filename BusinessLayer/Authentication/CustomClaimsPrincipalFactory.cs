using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authentication
{
    public class CustomClaimsPrincipalFactory :
		UserClaimsPrincipalFactory<AppUser, AppRole>
	{
		public CustomClaimsPrincipalFactory(
			UserManager<AppUser> userManager,
			RoleManager<AppRole> roleManager,
			IOptions<IdentityOptions> options) 
			: base(userManager, roleManager, options)
		{
		}

		public async override Task<ClaimsPrincipal> CreateAsync(AppUser user)
		{
			ClaimsPrincipal claimsPrincipal = await base.CreateAsync(user);

			CustomClaims customClaims = new(user);
			((ClaimsIdentity)claimsPrincipal.Identity).AddClaims(new[]
			{
				customClaims.GetAge(),
			});

			return claimsPrincipal;
		}
	}
}
