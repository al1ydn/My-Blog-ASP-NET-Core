using BusinessLayer.Validation.Configuration;
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
    public class UserEditModel
    {
        public string? Name { get; set; }
        public string? About { get; set; }
        public string? Image { get; set; }
        public string? UserName { get; set; }
        public string? InitialUserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class UserEditModelValidator : AbstractValidator<UserEditModel>
    {
        public UserEditModelValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(CharacterLimits.Line1);

            RuleFor(x => x.About)
                .MaximumLength(CharacterLimits.Paragraph1);

            RuleFor(x => x.Image)
                .MaximumLength(CharacterLimits.Page1);

            RuleFor(x => x.UserName)
                .AppUserUserName();

            RuleFor(x => x.InitialUserName)
                .AppUserUserName();

            RuleFor(x => x.Email)
                .AppUserEmail();

            RuleFor(x => x.Password)
                .AppUserPassword(NotNull: false);
        }
    }
}
