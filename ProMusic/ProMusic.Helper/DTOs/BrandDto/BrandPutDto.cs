using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.BrandDto
{
    public class BrandPutDto
    {
        public string Name { get; set; }
    }
    public class BrandPutDtoValidator : AbstractValidator<BrandPutDto>
    {
        public BrandPutDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character");
        }
    }
}
