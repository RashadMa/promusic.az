using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.ProductDto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public double? Rate { get; set; }
        public string Image { get; set; }
    }
}
