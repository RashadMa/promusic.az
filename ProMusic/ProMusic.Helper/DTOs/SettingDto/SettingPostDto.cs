using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.SettingDto
{
    public class SettingPostDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IFormFile Photo { get; set; }
    }
}
