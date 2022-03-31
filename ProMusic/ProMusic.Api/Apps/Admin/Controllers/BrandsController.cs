using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Data;
using ProMusic.Data.Repositories;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.BrandDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]"), ApiController]
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        #region Create

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] BrandPostDto brandPostDto)
        {
            var brand = await _brandService.CreateAsync(brandPostDto);
            return StatusCode(201, brand);
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _brandService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _brandService.GetAll(page));
        }

        #endregion

        #region Update

        [HttpPut("{id}")]        
        public async Task<IActionResult> Update(int id, BrandPutDto brandPutDto)
        {
            await _brandService.UpdateAsync(id, brandPutDto);
            return NoContent();
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _brandService.Delete(id);
            return NoContent();
        }

        #endregion
    }
}
