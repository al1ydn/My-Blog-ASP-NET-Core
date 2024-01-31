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
	public static class AppUserPasswordValidator
	{
		public static IRuleBuilderOptions<T, string>
			AppUserPassword<T>(this IRuleBuilder<T, string> ruleBuilder, 
				bool NotNull = true)
		{
			if (NotNull)
			{
				ruleBuilder.NotNull();
			}

			return ruleBuilder
				.Length(8, CharacterLimits.Paragraph1)
				.OnlyPrintableAscii()
				.ContainsLowercase()
				.ContainsUppercase()
				.ContainsDigit()
				.ContainsNonAlphanumeric();
		}
	}
}
