using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.DTOs.CategoryDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Member.Controllers
{
    [Route("member/api/[controller]"), ApiController]
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            return Ok(await _subCategoryService.GetByIdAsync(id));
        }

        #endregion

        #region Get all with page

        [HttpGet("")]
        public async Task<IActionResult> GetAllCategories(int page = 1)
        {
            return Ok(await _subCategoryService.GetAll(page));
        }

        #endregion
    }
}
