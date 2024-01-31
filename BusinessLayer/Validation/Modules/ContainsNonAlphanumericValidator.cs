using BusinessLayer.Services;
using BusinessLayer.Validation.Configuration;
using FluentValidation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.Modules.AppUser
{
    public static class ContainsNonAlphanumericValidator
	{
        public static IRuleBuilderOptions<T, string>
            ContainsNonAlphanumeric<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
			return ruleBuilder
				.Must(value =>
				{
					if (value == null)
					{
						return true;
					}

					return value.Any(element =>
						ASCIICodes.NonAlphaNumerics.Contains(element));

					/*
					return x.Any(x =>
						((x >= 33) && (x <= 47)) ||
						((x >= 58) && (x <= 64)) ||
						((x >= 91) && (x <= 96)) ||
						((x >= 123) && (x <= 126)));
					*/
				})
				.WithMessage(Messages.ContainsNonAlphanumericMessage);
		}
    }
}
