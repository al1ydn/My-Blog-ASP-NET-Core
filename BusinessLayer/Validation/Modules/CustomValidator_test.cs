using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.Modules.AppUser
{
	public static class CustomValidator_test
	{
		public static IRuleBuilderOptionsConditions<T, string>
			Custom<T>(this IRuleBuilder<T, string> ruleBuilder, int num)
		{
			return ruleBuilder
				.Custom((x, context) =>
				{
					if (x != null &&
						x.Any(x =>
							(x >= 48) &&
							(x <= 57)))
					{
						context.AddFailure("Rakam içermeli.");
					}
					else if(x == "a")
					{
						context.AddFailure("Başka bir hata mesajı.");
					}
				});
		}
	}
}
