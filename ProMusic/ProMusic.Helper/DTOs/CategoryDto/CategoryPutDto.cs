using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.CategoryDto
{
    public class CategoryPutDto
    {
        public string Name { get; set; }
        public bool IsSubCategory { get; set; }
    }
    public class CategoryPutDtoValidator : AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character");
        }
    }
}
