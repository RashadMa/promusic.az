using System;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.CategoryDto
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
        public bool IsSubCategory { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character")
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.IsSubCategory)
                .NotNull()
                .WithMessage("You must choose sub-category");
        }
    }
}
