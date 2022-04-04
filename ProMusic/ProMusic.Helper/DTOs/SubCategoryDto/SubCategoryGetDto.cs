using System;
namespace ProMusic.Helper.DTOs.SubCategoryDto
{
    public class SubCategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
