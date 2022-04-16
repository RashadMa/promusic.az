using System;
namespace ProMusic.Helper.DTOs.CommentDto
{
    public class CommentGetDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte Rate { get; set; }
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
    }
}
