using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProMusic.Api.Apps.Member.Controllers
{
    [Route("manage/api/[controller]")]
    public class SlidersController : Controller
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(int id)
        {
            return Ok(await _sliderService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAllSliders(int page = 1)
        {
            return Ok(await _sliderService.GetAll(page));
        }

        #endregion
    }
}
