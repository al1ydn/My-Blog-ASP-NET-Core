using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.AuthorizeAttributes.OnlyAnonymous
{
    public class OnlyAnonymousRequirement : IAuthorizationRequirement
    {
    }
}
