using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.Entities.Blog
{
    public static class BlogOperations
    {
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement 
            { 
                Name = BlogConstants.CreateOperationName 
            };
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement 
            { 
                Name = BlogConstants.DeleteOperationName 
            };
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement 
            { 
                Name = BlogConstants.UpdateOperationName 
            };
    }
}

public class BlogConstants
{
    public static readonly string CreateOperationName = "Create";
    public static readonly string DeleteOperationName = "Delete";
    public static readonly string UpdateOperationName = "Update";
}