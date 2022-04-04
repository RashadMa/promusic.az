using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.SettingDto
{
    public class SettingListItemDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
