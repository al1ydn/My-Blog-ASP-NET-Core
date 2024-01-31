using BusinessLayer.Validation.Configuration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.Modules.AppUser
{
	public static class AppUserEmailValidator
	{
		public static IRuleBuilderOptions<T, string>
			AppUserEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder
				.NotNull()
				.Length(5, CharacterLimits.Page1)
				.EmailFormat();
			//TODO: Is already used?
		}
	}
}
