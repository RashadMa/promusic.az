using System;
namespace ProMusic.Helper.DTOs.ProductDto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public double? Rate { get; set; }
    }
}
