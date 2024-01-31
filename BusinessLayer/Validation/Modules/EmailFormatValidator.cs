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
    public static class EmailFormatValidator
	{
        public static IRuleBuilderOptions<T, string>
			EmailFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
			return ruleBuilder
				.Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
				.WithMessage(Messages.EmailFormatMessage);
		}
    }
}
