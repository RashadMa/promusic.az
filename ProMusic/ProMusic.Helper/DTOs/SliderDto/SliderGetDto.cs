using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.SliderDto
{
    public class SliderGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BtnText { get; set; }
        public string BtnUrl { get; set; }
        public int Order { get; set; }
        public bool IsDeleted { get; set; }
        public string Image { get; set; }
    }
}
