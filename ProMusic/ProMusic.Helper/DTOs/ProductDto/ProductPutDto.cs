using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.ProductDto
{
    public class ProductPutDto
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
    public class ProductPutDtoValidator : AbstractValidator<ProductPutDto>
    {
        public ProductPutDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character");

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Sale price cannot be 0");

            RuleFor(x => x.CostPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Cost price cannot be 0");
        }
    }
}
