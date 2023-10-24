using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
	public class WriterValidator : AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			// Name
			RuleFor(x => x.Name).NotEmpty().WithMessage("En az 3 karakter girin.");
			RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karakter girin.");
			RuleFor(x => x.Name).MaximumLength(30).WithMessage("En fazla 30 karakter girin.");

			// About
			RuleFor(x => x.About).MaximumLength(300).WithMessage("En fazla 300 karakter girin.");

			// Image
			//

			// Mail
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Geçerli bir mail adresi girin.");
			RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli bir mail adresi girin.");

			// Password
			RuleFor(x => x.Password).NotEmpty().WithMessage("En az 6 karakter girin.");
			RuleFor(x => x.Password).MinimumLength(6).WithMessage("En az 6 karakter girin.");
			RuleFor(x => x.Password).MaximumLength(30).WithMessage("En fazla 30 karakter girin.");
			RuleFor(x => x.Password).Matches(@"[A-Z]").WithMessage("En az bir büyük harf girin");
			RuleFor(x => x.Password).Matches(@"[a-z]").WithMessage("En az bir küçük harf girin");
			RuleFor(x => x.Password).Matches(@"[!""#$%&'()*+,-./:;<=>?@[\]^_`{|}~]").WithMessage("En az bir özel harf girin");

			// PasswordConfirm
			RuleFor(x => x.PasswordConfirm).Equal(x => x.Password).WithMessage("Eşleşen bir parola girin.");
		}
	}
}
