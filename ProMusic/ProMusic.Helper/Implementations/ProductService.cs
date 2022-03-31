using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.ProductDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<ProductGetDto> CreateAsync( [FromForm] ProductPostDto postDto)
        {
            if (await _unitOfWork.ProductRepository.IsExist(x => x.Name.ToUpper().Trim() == postDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Product already exist");

            string fileName = "";
            if (postDto.Photo != null)
            {
                fileName = postDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(postDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/products", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    postDto.Photo.CopyTo(stream);
                }
            }

            Product product = _mapper.Map<Product>(postDto);

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return new ProductGetDto
            {
                Id = product.Id,
                Name = product.Name,
                SalePrice = product.SalePrice,
                CostPrice = product.CostPrice,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                Image = product.Image,
            };
        }

        #endregion

        #region Get

        public async Task<ProductGetDto> GetByIdAsync(int id)
        {
            Product product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (product is null) throw new NotFoundException("Item not found");
            ProductGetDto productGetDto = _mapper.Map<ProductGetDto>(product);
            return productGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<ProductListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.ProductRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<ProductListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ProductListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    SalePrice = x.SalePrice,
                    DiscountPercent = x.DiscountPercent,
                    Rate = x.Rate,
                })
                .ToList();

            var listDto = new PagenatedListDto<ProductListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, ProductPutDto productPutDto)
        {
            Product product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (product is null) throw new NotFoundException("Item not found");
            if (await _unitOfWork.ProductRepository.IsExist(x => x.Id != id && x.Name.ToUpper().Trim() == productPutDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Product already exist");
            product.Name = productPutDto.Name;
            product.SalePrice = productPutDto.SalePrice;
            product.DiscountPercent = productPutDto.DiscountPercent;
            product.BrandId = productPutDto.BrandId;
            product.CategoryId = productPutDto.CategoryId;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Product product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (product is null) throw new NotFoundException("Item not found");
            product.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
