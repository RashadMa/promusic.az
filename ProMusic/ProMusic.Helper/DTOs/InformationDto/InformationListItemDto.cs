using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.InformationDto
{
    public class InformationListItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Photo { get; set; }
    }
}
