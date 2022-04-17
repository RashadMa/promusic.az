using System;
namespace ProMusic.Helper.DTOs.OrderDto
{
    public class OrderItemGetDto
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
