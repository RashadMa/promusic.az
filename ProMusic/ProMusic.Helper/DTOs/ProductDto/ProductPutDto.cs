using System;
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
}
