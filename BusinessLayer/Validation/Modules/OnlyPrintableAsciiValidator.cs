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
    public static class OnlyPrintableAsciiValidator
	{
        public static IRuleBuilderOptions<T, string>
			OnlyPrintableAscii<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
			return ruleBuilder
				.Must(value =>
				{
					if (value == null)
					{
						return true;
					}

					return value.All(element => 
						ASCIICodes.Printables.Contains(element));

					/*
					return value.All(x =>
						(x >= 33) &&
						(x <= 126));
					*/
				})
				.WithMessage(Messages.OnlyPrintableAsciiMessage);
		}
    }
}
