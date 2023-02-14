using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Application.RequestModels.User.Validators
{
    public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("UserName is empty!")
                .Length(5,256).WithMessage("UserName length must be between 5 and 255 symbols")
                .Must(x => x.All(Char.IsLetter)).WithMessage("UsserName must include only letters"); ;
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email is empty!")
                .EmailAddress().WithMessage("Email address has invalid format!")
                .MaximumLength(256).WithMessage("Email address must be shorter than 256 symbols");

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("Phone number is empty!")
                .Length(12).WithMessage("Phone number length must be 12 symbols")
                .Must(IsPhoneValid).WithMessage("Invalid phone number format");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password is empty!");
        }

        private bool IsPhoneValid(string phone)
        {
            return !(!phone.StartsWith("+7")
            || !phone[1..].All(c => Char.IsDigit(c)));
        }

    }
}
