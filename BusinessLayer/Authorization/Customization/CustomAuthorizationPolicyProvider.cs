using BusinessLayer.Authorization.AuthorizeAttributes.MinimumAge;
using BusinessLayer.Authorization.AuthorizeAttributes.OnlyAnonymous;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.Customization
{
    public class CustomAuthorizationPolicyProvider 
        : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "MinimumAge";
        private DefaultAuthorizationPolicyProvider BackupPolicyProvider { get; }

        public CustomAuthorizationPolicyProvider(
            IOptions<AuthorizationOptions> options)
        {
            BackupPolicyProvider = 
                new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
            BackupPolicyProvider.GetDefaultPolicyAsync();

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() =>
            BackupPolicyProvider.GetFallbackPolicyAsync();

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
                int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var age))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new MinimumAgeRequirement(age));

                return Task.FromResult(policy.Build());
            }

            return BackupPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
