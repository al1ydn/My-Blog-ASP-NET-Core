using BusinessLayer.Validation.Modules.AppUser;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.User
{
    public class ResendConfirmationEmailViewModel
    {
        public string? Email { get; set; }
    }

    public class ResendConfirmationEmailViewModelValidator : AbstractValidator<ResendConfirmationEmailViewModel>
    {
        public ResendConfirmationEmailViewModelValidator()
        {
            RuleFor(x => x.Email)
                .AppUserEmail();
        }
    }
}
