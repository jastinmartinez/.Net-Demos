using System;
using FluentValidation;

namespace Lab02.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Email Address is Required");
            RuleFor(x => x.Password).NotNull().WithMessage("Password is Required");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Password is Required").Equal(x => x.Password).WithMessage("Password don't Match");
            RuleFor(x => x.UserName).NotNull().WithMessage("User is Required").Length(10, 20).WithMessage("User Must be between 10 and 20 characters");
        }
    }
}
