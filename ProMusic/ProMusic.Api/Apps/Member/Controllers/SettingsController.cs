using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Member.Controllers
{
    [Route("manage/api/[controller]")]
    public class SettingsController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSetting(int id)
        {
            return Ok(await _settingService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAllSettings(int page = 1)
        {
            return Ok(await _settingService.GetAll(page));
        }

        #endregion
    }
}
