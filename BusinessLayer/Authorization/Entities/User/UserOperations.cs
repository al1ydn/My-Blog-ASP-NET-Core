using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.Entities.User
{
    public static class UserOperations
    {
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement 
            { 
                Name = UserConstants.UpdateOperationName 
            };
    }
}

public class UserConstants
{
    public static readonly string UpdateOperationName = "Update";
}
