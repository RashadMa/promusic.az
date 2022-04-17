using System;
using FluentValidation;
using ProMusic.Helper.DTOs.OrderDto;

namespace ProMusic.Helper.DTOs.OrderDto
{
    public class OrderItemPostDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}
public class OrderItemPostDtoValidator : AbstractValidator<OrderItemPostDto>
{
    public OrderItemPostDtoValidator()
    {
        RuleFor(x => x.SalePrice)
            .NotEmpty()
            .WithMessage("Sale price is required!")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Sale price cannot be 0");

        RuleFor(x => x.CostPrice)
            .NotEmpty()
            .WithMessage("Cost price is required!")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Cost price cannot be 0");

        RuleFor(x => x.DiscountedPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Discounted price cannot be 0");
    }
}