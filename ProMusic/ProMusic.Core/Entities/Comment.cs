using System;
using System.ComponentModel.DataAnnotations;

namespace ProMusic.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        [Range(1, 5)]
        public byte Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}
