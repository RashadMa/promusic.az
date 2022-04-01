using System;
using Microsoft.AspNetCore.Http;

namespace ProMusic.Helper.DTOs.SettingDto
{
    public class SettingListItemDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
<<<<<<< HEAD
        public string Image { get; set; }
=======
        public IFormFile Photo { get; set; }
>>>>>>> 2aabfc1c09e750146f34fe04d9770d7e625d6215
    }
}
