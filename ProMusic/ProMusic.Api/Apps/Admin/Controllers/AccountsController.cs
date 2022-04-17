using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProMusic.Core.Entities;
using ProMusic.Data;
using ProMusic.Helper.DTOs.AccountDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]"), ApiController]
    public class AccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly DataContext _context;
        private readonly IAccountService _accountServie;

        public AccountsController(UserManager<AppUser> userManager,
                                  RoleManager<IdentityRole> roleManager,
                                  SignInManager<AppUser> signInManager,
                                  DataContext context,
                                  IAccountService accountService
                                  )
        {
            _userManager = userManager;
            _accountServie = accountService;
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
            var userRoles = _context.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
            var roleName = _context.Roles.FirstOrDefault(x=>x.Id == userRoles.RoleId).Name;
            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = tokenStr, userRoleName = roleName });
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _accountServie.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _accountServie.GetAll(page));
        }

        #endregion
    }
}