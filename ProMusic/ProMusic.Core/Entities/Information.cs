using System;
namespace ProMusic.Core.Entities
{
    public class Information
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool IsDeleted { get; set; }
    }
}