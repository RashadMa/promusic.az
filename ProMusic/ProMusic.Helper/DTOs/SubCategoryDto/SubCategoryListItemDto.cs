using System;
namespace ProMusic.Helper.DTOs.SubCategoryDto
{
    public class SubCategoryListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
    }
}
