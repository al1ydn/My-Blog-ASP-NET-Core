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
    public class UserSignInModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class UserSignInModelValidator : AbstractValidator<UserSignInModel>
    {
        public UserSignInModelValidator()
        {
            RuleFor(x => x.UserName)
                .AppUserUserName();

            RuleFor(x => x.Password)
                .AppUserPassword();
        }
    }
}
