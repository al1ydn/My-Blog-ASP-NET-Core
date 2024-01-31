using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Authorization.AuthorizeAttributes.MinimumAge
{
    public class MinimumAgeAuthorizeAttribute : AuthorizeAttribute
    {
        const string POLICY_PREFIX = "MinimumAge";

        public MinimumAgeAuthorizeAttribute(int age) => Age = age;

        public int Age
        {
            get
            {
                if (int.TryParse(Policy.Substring(POLICY_PREFIX.Length), out var age))
                {
                    return age;
                }
                return default;
            }
            set
            {
                Policy = $"{POLICY_PREFIX}{value.ToString()}";
            }
        }
    }
}
