using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.CategoryDto
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}
