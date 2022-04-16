using System;
namespace ProMusic.Helper.DTOs.CommentDto
{
    public class CommentPostDto
    {
        public string Text { get; set; }
        public byte Rate { get; set; }
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
    }
}
