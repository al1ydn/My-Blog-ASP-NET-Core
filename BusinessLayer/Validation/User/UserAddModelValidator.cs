using BusinessLayer.Validation.Modules.AppUser;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.User
{
    public class UserAddModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }

    public class UserAddModelValidator : AbstractValidator<UserAddModel>
    {
        public UserAddModelValidator()
        {
            RuleFor(x => x.UserName)
                .AppUserUserName();

            RuleFor(x => x.Password)
                .AppUserPassword();

            RuleFor(x => x.Email)
                .AppUserEmail();
        }
    }
}
