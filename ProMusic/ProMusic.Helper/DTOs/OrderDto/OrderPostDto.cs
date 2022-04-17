using System;
using FluentValidation;
using ProMusic.Core.Enums;
using ProMusic.Helper.DTOs.OrderDto;

namespace ProMusic.Helper.DTOs.OrderDto
{
    public class OrderPostDto
    {
        public OrderStatus Status { get; set; }
        public string AppUserId { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
public class OrderPostDtoValidator : AbstractValidator<OrderPostDto>
{
    public OrderPostDtoValidator()
    {
        RuleFor(x => x.Email)
            .MaximumLength(30);

        RuleFor(x => x.Adress)
            .MaximumLength(100)
            .WithMessage("Max length must be less than 100")
            .NotEmpty()
            .WithMessage("Adress is required");

        RuleFor(x => x.Phone)
           .MaximumLength(100)
           .WithMessage("Max length must be less than 100")
           .NotEmpty()
           .WithMessage("Phone is required");
    }
}