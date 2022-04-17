using System;
namespace ProMusic.Core.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
