using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.CategoryDto
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Image { get; set; }
    }
}
