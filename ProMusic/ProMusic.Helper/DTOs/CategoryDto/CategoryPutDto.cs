using System;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.CategoryDto
{
    public class CategoryPutDto
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class CategoryPutDtoValidator : AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidator()
        {
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Photo != null)
                {
                    if (x.Photo?.ContentType != "image/jpeg" && x.Photo.ContentType != "image/png")
                        context.AddFailure("ImageFile", "File type must be jpeg or png");
                }
            });

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Photo != null)
                {
                    if (x.Photo?.Length > 4194304)
                        context.AddFailure("ImageFile", "file size must be less than 4mb");

                }
            });

            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character");
        }
    }
}
