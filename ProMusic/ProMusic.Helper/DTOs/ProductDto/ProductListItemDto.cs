using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ProMusic.Helper.DTOs.BrandDto;
using ProMusic.Helper.DTOs.CommentDto;

namespace ProMusic.Helper.DTOs.ProductDto
{
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public double? Rate { get; set; }
        public int SubCategoryId { get; set; }
        public string Desc { get; set; }
        public List<CommentGetDto> Comments { get; set; }
        public BrandGetDto Brand { get; set; }
    }
}
