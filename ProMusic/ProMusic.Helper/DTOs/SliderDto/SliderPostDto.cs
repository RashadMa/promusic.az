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
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Photo.ContentType != "image/jpeg" && x.Photo.ContentType != "image/png")
                    context.AddFailure("ImageFile", "File type must be jpeg or png");
            });
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Photo.Length > 4194304)
                    context.AddFailure("ImageFile", "file size must be less than 4mb");
            });

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
