using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.AuthorizeAttributes.MinimumAge
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public MinimumAgeRequirement(int minimumAge) =>
            MinimumAge = minimumAge;

        public int MinimumAge { get; }
    }
}
