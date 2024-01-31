using BusinessLayer.Validation.Configuration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.Modules.AppUser
{
    public static class AppUserUserNameValidator
    {
        public static IRuleBuilderOptions<T, string>
            AppUserUserName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .Length(3, CharacterLimits.Word1)
                .UsernameCharacters();
            //TODO: Is already used?
        }
    }
}
