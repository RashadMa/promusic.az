using System;
namespace ProMusic.Core.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Desc { get; set; }
        public string BtnText { get; set; }
        public string BtnUrl { get; set; }
        public int Order { get; set; }
        public bool IsDeleted { get; set; }
    }
}
