using System;
using FluentValidation;

namespace ProMusic.Helper.DTOs.AccountDto
{
    public class LoginDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
