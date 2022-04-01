using System;
namespace ProMusic.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CratedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
