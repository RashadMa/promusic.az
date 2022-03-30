using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.InformationDto
{
    public class InformationDto
    {
        public string Tittle { get; set; }
        public string Desc { get; set; }
        public IFormFile Photo { get; set; }
    }
}
