using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.DTOs.SubCategoryDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]"), ApiController]
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        #region Create

        [HttpPost("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] SubCategoryPostDto postDto)
        {
            var subCategory = await _subCategoryService.CreateAsync(postDto);
            return StatusCode(201, subCategory);
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _subCategoryService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _subCategoryService.GetAll(page));
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] SubCategoryPostDto categoryPutDto)
        {
            await _subCategoryService.UpdateAsync(id, categoryPutDto);
            return NoContent();
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _subCategoryService.Delete(id);
            return NoContent();
        }

        #endregion
    }
}
