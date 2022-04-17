using System;
using Microsoft.AspNetCore.Identity;

namespace ProMusic.Core.Entities
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
