﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProMusic.Core.Entities;
using ProMusic.Data;
using ProMusic.Data.Repositories;
using ProMusic.Service.DTOs.BrandDto;

namespace ProMusic.Apps.Admin.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private readonly BrandRepository _brandRepository;
        private readonly DataContext _context;

        public BrandsController(DataContext context, BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
            _context = context;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(BrandPostDto brandPostDto)
        {
            if (await _context.Brands.AnyAsync(x => x.Name.Trim().ToUpper() == brandPostDto.Name.Trim().ToUpper())) return StatusCode(409);

            Brand brand = new Brand
            {
                Name = brandPostDto.Name,
                IsDeleted = false
            };

            await _brandRepository.AddAsync(brand);
            await _brandRepository.SaveAsync();

            return StatusCode(201, new { id = brand.Id });
        }        
    }
}
