using System;
namespace ProMusic.Helper.DTOs.CategoryDto
{
    public class CategoryListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubCategory { get; set; }
    }
}
