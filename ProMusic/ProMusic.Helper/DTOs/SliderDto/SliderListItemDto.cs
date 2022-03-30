using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.SliderDto
{
    public class SliderListItemDto
    {
        public IFormFile Photo { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
    }
}
