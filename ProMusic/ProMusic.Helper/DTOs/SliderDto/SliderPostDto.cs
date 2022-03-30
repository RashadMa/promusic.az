using System;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.SliderDto
{
    public class SliderPostDto
    {
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string BtnUrl { get; set; }
        public string BtnText { get; set; }
        public int Order { get; set; }
    }
    public class SliderPostDtoValidator : AbstractValidator<SliderPostDto>
    {
        public SliderPostDtoValidator()
        {
            RuleFor(x => x.Title)
               .MaximumLength(30)
               .WithMessage("Max length must be less than 30 character");

            RuleFor(x => x.BtnText)
               .MaximumLength(30)
               .WithMessage("Max length must be less than 30 character");

            RuleFor(x => x.BtnUrl)
               .MaximumLength(100)
               .WithMessage("Max length must be less than 100 character");
        }
    }
}
