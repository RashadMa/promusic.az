using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.ProductDto
{
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}
