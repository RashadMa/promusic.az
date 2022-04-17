using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProMusic.Core.Entities;
using ProMusic.Data;
using ProMusic.Helper.DTOs.AccountDto;

namespace ProMusic.Api.Apps.Member.Controllers
{
    [Route("member/api/[controller]"), ApiController]
    public class AccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly DataContext _context;

        public AccountsController(UserManager<AppUser> userManager,
                                  RoleManager<IdentityRole> roleManager,
                                  SignInManager<AppUser> signInManager,
                                  DataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        #region Login

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            AppUser user = await _userManager.FindByNameAsync(loginDto.Name);
            if (user is null) return NotFound();
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) return NotFound();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim("Name",user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList());
            string keyStr = "241da6d5-5162-40de-ab6f-e619832d355c";
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(keyStr));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: creds,
                    expires: DateTime.Now.AddDays(3),
                    issuer: "https://localhost:5001/",
                    audience: "https://localhost:5001/"
                );
            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = tokenStr });
        }

        #endregion

        #region Register

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            AppUser user = await _userManager.FindByNameAsync(registerDto.Name);
            if (user != null) return StatusCode(500, "Internal server error");
            user = new AppUser
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                UserName = registerDto.Email,
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return StatusCode(500, "Internal server error");
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) return StatusCode(500, "Internal server error");
            await _signInManager.SignInAsync(user, true);
            return Ok(user);
        }

        #endregion        
    }
}
