using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.DTOs.InformationDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]"), ApiController]
    public class InformationsController : Controller
    {
        private readonly IInformationService _informationService;

        public InformationsController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        #region Create

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] InformationPostDto postDto)
        {
            var information = await _informationService.CreateAsync(postDto);
            return StatusCode(201, information);
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _informationService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _informationService.GetAll(page));
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InformationPostDto informationPostDto)
        {
            await _informationService.UpdateAsync(id, informationPostDto);
            return NoContent();
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _informationService.Delete(id);
            return NoContent();
        }

        #endregion
    }
}
