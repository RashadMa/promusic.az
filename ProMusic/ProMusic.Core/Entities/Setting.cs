using System;
namespace ProMusic.Core.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}