using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.InformationDto
{
    public class InformationListItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
