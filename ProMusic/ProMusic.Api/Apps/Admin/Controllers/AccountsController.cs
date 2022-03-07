using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs.AccountDto;

namespace ProMusic.Api.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]"), ApiController]
    public class AccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountsController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
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
                new Claim("Name",user.Name)
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
            AppUser user = await _userManager.FindByNameAsync(registerDto.UserName);
            if (user != null) return BadRequest();
            user = new AppUser
            {
                Name = registerDto.Name,
                UserName = registerDto.UserName,
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest();
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) return BadRequest();
            await _signInManager.SignInAsync(user, true);
            return Ok();
        }

        #endregion

        #region Create role and user

        //[HttpGet("")]
        //public async Task<IActionResult> CreateRole()
        //{
        //    var result1 = _roleManager.CreateAsync(new IdentityRole("Admin")).Result;
        //    var result2 = _roleManager.CreateAsync(new IdentityRole("Member")).Result;

        //    var user1 = new AppUser { Name = "Rashad", UserName = "Rashad", IsAdmin = false };
        //    var user2 = new AppUser { Name = "Super", UserName = "SuperAdmin", IsAdmin = true };
        //    var result3 = await _userManager.CreateAsync(user1, "Rashad123");
        //    var result4 = await _userManager.CreateAsync(user2, "Rashad123");

        //    return Ok(new { resul1 = result3, resul2 = result4});

        //    var result5 = _userManager.AddToRoleAsync(user1, "Member").Result;
        //    var result6 = _userManager.AddToRoleAsync(user2, "Admin").Result;

        //    return Ok();
        //}

        #endregion
    }
}
