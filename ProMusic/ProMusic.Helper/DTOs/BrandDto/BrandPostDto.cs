using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.BrandDto
{
    public class BrandPostDto
    {
        public string Name { get; set; }
    }
    public class BrandPostDtoValidator : AbstractValidator<BrandPostDto>
    {
        public BrandPostDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character")
                .NotEmpty()
                .WithMessage("Name is required");
        }
    }
}