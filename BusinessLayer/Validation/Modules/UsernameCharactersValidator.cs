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
    public static class UsernameCharactersValidator
	{
        public static IRuleBuilderOptions<T, string>
			UsernameCharacters<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
			return ruleBuilder
				//.Matches(@"^[a-zA-Z0-9._]*$")
				.Must(value =>
				{
					if (value == null)
					{
						return true;
					}

					return value.All(element =>
					{
						if (ASCIICodes.AlphaNumerics.Contains(element) ||
							element == '.' ||
							element == '_')
						{
							return true;
						}

						return false;
					});
				})
				.WithMessage(Messages.OnlyAlphaNumericMessage);
		}
    }
}
