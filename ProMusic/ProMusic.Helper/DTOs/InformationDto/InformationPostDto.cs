using System;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.InformationDto
{
    public class InformationPostDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class InformationPostDtoValidator : AbstractValidator<InformationPostDto>
    {
        public InformationPostDtoValidator()
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
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character");

            RuleFor(x => x.Desc)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character");
        }
    }
}
