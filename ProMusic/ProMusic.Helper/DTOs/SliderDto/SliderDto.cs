using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.SliderDto
{
    public class SliderDto
    {
        public string Title { get; set; }
        public string BtnText { get; set; }
        public string BtnUrl { get; set; }
        public string Image { get; set; }
    }
}
