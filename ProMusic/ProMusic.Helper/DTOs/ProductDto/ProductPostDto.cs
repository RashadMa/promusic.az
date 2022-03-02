using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.ProductDto
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
    }
    public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character")
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.SalePrice)
                .NotEmpty()
                .WithMessage("Sale price is required!");

            RuleFor(x => x.CostPrice)
                .NotEmpty()
                .WithMessage("Cost price is required!");
        }
    }
}
