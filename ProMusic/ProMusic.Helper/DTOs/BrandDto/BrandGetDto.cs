using System;
using System.Collections.Generic;
using ProMusic.Helper.DTOs.ProductDto;

namespace ProMusic.Helper.DTOs.BrandDto
{
    public class BrandGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductGetDto> Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
