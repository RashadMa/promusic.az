using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.SettingDto
{
    public class SettingListItemDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Image { get; set; }
    }
}
