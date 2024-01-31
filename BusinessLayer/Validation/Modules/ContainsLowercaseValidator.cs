using BusinessLayer.Services;
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
    public static class ContainsLowercaseValidator
	{
        public static IRuleBuilderOptions<T, string>
			ContainsLowercase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
			return ruleBuilder
				.Must(value =>
				{
					if (value == null)
					{
						return true;
					}

					return value.Any(element =>
						ASCIICodes.Lowercases.Contains(element));
				})
				.WithMessage(Messages.ContainsLowercaseMessage);
		}
    }
}
