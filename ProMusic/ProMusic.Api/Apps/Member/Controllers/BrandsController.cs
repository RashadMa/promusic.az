using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Core;
using ProMusic.Helper.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace ProMusic.Api.Apps.Member.Controllers
{
    [Route("member/api/[controller]"), ApiController]
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            return Ok(await _brandService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAllBrands(int page = 1)
        {
            return Ok(await _brandService.GetAll(page));
        }

        #endregion
    }
}
