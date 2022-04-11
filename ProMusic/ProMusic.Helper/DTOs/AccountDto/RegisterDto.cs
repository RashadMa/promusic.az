using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.AccountDto
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .MaximumLength(30)
                .WithMessage("Max Length must be less than 30")
                .MinimumLength(5)
                .WithMessage("Min Length must be greater than 5")
                .NotNull()
                .WithMessage("Email is required");

            RuleFor(x => x.Name)
                .MinimumLength(2)
                .WithMessage("Min Length must be greater than 2")
                .MaximumLength(30)
                .WithMessage("Max Length must be less than 30")
                .NotNull()
                .WithMessage("Name is required");

            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(30);
        }
    }
}
