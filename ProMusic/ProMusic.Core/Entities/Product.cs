using System;
using System.ComponentModel.DataAnnotations;

namespace ProMusic.Core.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        [Range(1, 5)]
        public double? Rate { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
