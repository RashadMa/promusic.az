using System;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.ProductDto
{
    public class ProductPutDto
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Desc { get; set; }
        public int BrandId { get; set; }
        public int SubCategoryId { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class ProductPutDtoValidator : AbstractValidator<ProductPutDto>
    {
        public ProductPutDtoValidator()
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

            RuleFor(x => x.Desc)
                .MaximumLength(150)
                .WithMessage("Max length must be less than 150 character");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Max length must be less than 100 character");

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Sale price cannot be 0");

            RuleFor(x => x.CostPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Cost price cannot be 0");
        }
    }
}
