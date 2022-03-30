using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Helper.DTOs.ProductDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]"), ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        #region Create

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] ProductPostDto postDto)
        {
            var product = await _productService.CreateAsync(postDto);
            return StatusCode(201, product);
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _productService.GetAll(page));
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductPutDto productPutDto)
        {
            await _productService.UpdateAsync(id, productPutDto);
            return NoContent();
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return NoContent();
        }

        #endregion
    }
}
