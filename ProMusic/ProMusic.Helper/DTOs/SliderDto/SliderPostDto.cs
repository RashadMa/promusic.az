using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.SliderDto
{
    public class SliderPostDto
    {
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Desc { get; set; }
        public string BtnUrl { get; set; }
        public string BtnText { get; set; }
        public int Order { get; set; }
    }
    public class SliderPostDtoValidator : AbstractValidator<SliderPostDto>
    {
        public SliderPostDtoValidator()
        {
            RuleFor(x => x.Title1)
               .MaximumLength(30)
               .WithMessage("Max length must be less than 30 character");

            RuleFor(x => x.Title2)
               .MaximumLength(30)
               .WithMessage("Max length must be less than 30 character");

            RuleFor(x => x.Desc)
               .MaximumLength(100)
               .WithMessage("Max length must be less than 100 character");

            RuleFor(x => x.BtnText)
               .MaximumLength(30)
               .WithMessage("Max length must be less than 30 character");

            RuleFor(x => x.BtnUrl)
               .MaximumLength(100)
               .WithMessage("Max length must be less than 100 character");
        }
    }
}
