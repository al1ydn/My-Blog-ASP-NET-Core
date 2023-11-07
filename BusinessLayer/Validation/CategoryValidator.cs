using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
	public class CategoryValidator : AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			// Name
			RuleFor(x => x.Name).NotEmpty().WithMessage("Boş geçilemez.");
			RuleFor(x => x.Name).MaximumLength(30).WithMessage("En fazla 30 karakter girin.");

			// Description
			RuleFor(x => x.Description).MaximumLength(300).WithMessage("En fazla 300 karakter girin.");
		}
	}
}
