using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.DTOs.CategoryDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]"), ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region Create

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] CategoryPostDto postDto)
        {
            var category = await _categoryService.CreateAsync(postDto);
            return StatusCode(201, category);
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _categoryService.GetAll(page));
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CategoryPutDto categoryPutDto)
        {
            await _categoryService.UpdateAsync(id, categoryPutDto);
            return NoContent();
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return NoContent();
        }

        #endregion
    }
}
