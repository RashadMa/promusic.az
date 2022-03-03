using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.InformationDto
{
    public class InformationPostDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
    }
    public class InformationPostDtoValidator : AbstractValidator<InformationPostDto>
    {
        public InformationPostDtoValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character");

            RuleFor(x => x.Desc)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character");
        }
    }
}
