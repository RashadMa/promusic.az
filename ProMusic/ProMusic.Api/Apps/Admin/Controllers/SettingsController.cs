using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.DTOs.SettingDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]"), ApiController]
    public class SettingsController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _settingService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _settingService.GetAll(page));
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] SettingPostDto settingPostDto)
        {
            await _settingService.UpdateAsync(id, settingPostDto);
            return NoContent();
        }

        #endregion
    }
}
