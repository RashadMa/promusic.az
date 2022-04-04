using System;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using ProMusic.Helper.DTOs.SubCategoryDto;

namespace ProMusic.Helper.DTOs.SubCategoryDto
{
    public class SubCategoryPostDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
public class SubCategoryPostDtoValidator : AbstractValidator<SubCategoryPostDto>
{
    public SubCategoryPostDtoValidator()
    {
        //RuleFor(x => x).Custom((x, context) =>
        //{
        //    if (x.Photo != null)
        //    {
        //        if (x.Photo?.ContentType != "image/jpeg" && x.Photo.ContentType != "image/png")
        //            context.AddFailure("ImageFile", "File type must be jpeg or png");
        //    }

        //});

        //RuleFor(x => x).Custom((x, context) =>
        //{
        //    if (x.Photo != null)
        //    {
        //        if (x.Photo?.Length > 4194304)
        //            context.AddFailure("ImageFile", "file size must be less than 4mb");

        //    }
        //});

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .WithMessage("Max length must be less than 100 character")
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.CategoryId)
           .NotEmpty()
           .WithMessage("Category Id is required");
    }
}