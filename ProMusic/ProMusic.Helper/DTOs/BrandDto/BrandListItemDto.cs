using System;
using System.Collections.Generic;
using ProMusic.Helper.DTOs.ProductDto;

namespace ProMusic.Helper.DTOs.BrandDto
{
    public class BrandListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductGetDto> Products { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
    }
}
