using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProMusic.Core.Entities;
using ProMusic.Data;
using ProMusic.Data.Repositories;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.BrandDto;

namespace ProMusic.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private readonly BrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandsController(BrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        #region Create

        [HttpPost("")]
        public async Task<IActionResult> Create(BrandPostDto brandPostDto)
        {
            if (await _brandRepository.IsExist(x => x.Name.Trim().ToUpper() == brandPostDto.Name.Trim().ToUpper())) return StatusCode(409);
            Brand brand = new Brand
            {
                Name = brandPostDto.Name,
                IsDeleted = false
            };
            await _brandRepository.AddAsync(brand);
            await _brandRepository.SaveAsync();
            return StatusCode(201, new { id = brand.Id });
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BrandGetDto), 200)]
        public async Task<IActionResult> Get(int id)
        {
            Brand brand = await _brandRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if (brand is null) return NotFound();
            BrandGetDto brandGetDto = _mapper.Map<BrandGetDto>(brand);
            return Ok(brandGetDto);
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            var query = _brandRepository.GetAll(x => x.IsDeleted == false);
            query = query.Where(x => x.IsDeleted);
            ListDto<BrandListItemDto> listDto = new ListDto<BrandListItemDto>
            {
                TotalCount = query.Count(),
                Items = query.Select(x => new BrandListItemDto { Id = x.Id, Name = x.Name }).ToList()
            };
            return Ok(listDto);
        }

        #endregion

        #region Edit

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Edit(int id, BrandPostDto brandPostDto)
        {
            Brand brand = await _brandRepository.GetAsync(x => x.Id == id);
            if (brand is null) return NotFound();
            brand.Name = brandPostDto.Name;
            brand.ModifiedAt = DateTime.UtcNow;
            await _brandRepository.SaveAsync();
            return NoContent();
        }

        #endregion
    }
}
