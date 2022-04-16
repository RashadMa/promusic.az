using System;
using ProMusic.Helper.DTOs.AccountDto;
using ProMusic.Helper.DTOs.ProductDto;

namespace ProMusic.Helper.DTOs.CommentDto
{
    public class CommentGetAllDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte Rate { get; set; }
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public AppUserGetDto AppUser { get; set; }
        public ProductGetDto Product { get; set; }
    }
}
