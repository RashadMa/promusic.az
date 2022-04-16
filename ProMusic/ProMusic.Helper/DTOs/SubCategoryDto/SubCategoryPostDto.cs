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