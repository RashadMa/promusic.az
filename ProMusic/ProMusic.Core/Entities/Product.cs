using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProMusic.Core.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Image { get; set; }
        [Range(1, 5)]
        public double? Rate { get; set; }
        public string Desc { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<Comment> Comments { get; set; }
        public Brand Brand { get; set; }
    }
}
