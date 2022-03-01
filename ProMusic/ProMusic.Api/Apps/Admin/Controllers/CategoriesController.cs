using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.DTOs.CategoryDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Admin.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region Create

        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryPostDto postDto)
        {
            try
            {
                var category = await _categoryService.CreateAsync(postDto);
                return StatusCode(201, category);
            }
            catch(RecordDuplicatedException exc)
            {
                return StatusCode(409, exc.Message);
            }
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _categoryService.GetByIdAsync(id));
            }
            catch (NotFoundException exc)
            {
                return NotFound(exc.Message);
            }
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            try
            {
                return Ok(await _categoryService.GetAll(page));
            }
            catch(System.Exception)
            {
                return StatusCode(500);
            }
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryPostDto categoryPostDto)
        {
            try
            {
                await _categoryService.UpdateAsync(id, categoryPostDto);
                return NoContent();
            }
            catch(NotFoundException exc)
            {
                return NotFound(exc.Message);
            }
            catch(RecordDuplicatedException exc)
            {
                return Conflict(exc.Message);
            }
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.Delete(id);
                return NoContent();
            }
            catch(NotFoundException exc)
            {
                return NotFound(exc.Message);
            }
        }

        #endregion
    }
}
