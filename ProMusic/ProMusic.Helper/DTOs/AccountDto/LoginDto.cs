using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.AccountDto
{
    public class LoginDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("Length must be greater than 3")
                .NotEmpty()
                .WithMessage("Name is required!")
                .MaximumLength(20)
                .WithMessage("Length must be less than 20");

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .WithMessage("Max length can be minimum 8")
                .NotEmpty()
                .WithMessage("Password is required!")
                .MaximumLength(20)
                .WithMessage("Max legth can be 20");
        }
    }
}
