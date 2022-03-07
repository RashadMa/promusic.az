using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.AccountDto
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(30)
                .NotNull();

            RuleFor(x => x.UserName)
                .NotNull()
                .MaximumLength(30);

            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(30);
        }
    }
}
