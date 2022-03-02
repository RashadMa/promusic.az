using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Data.Repositories;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.BrandDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<BrandGetDto> CreateAsync(BrandPostDto postDto)
        {
            if (await _unitOfWork.BrandRepository.IsExist(x => x.Name.ToUpper().Trim() == postDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Brand already exist");
            Brand brand = _mapper.Map<Brand>(postDto);
            await _unitOfWork.BrandRepository.AddAsync(brand);
            await _unitOfWork.SaveAsync();
            return new BrandGetDto
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }

        #endregion

        #region Get

        public async Task<BrandGetDto> GetByIdAsync(int id)
        {
            Brand brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (brand is null) throw new NotFoundException("Item not found");
            BrandGetDto brandGetDto = _mapper.Map<BrandGetDto>(brand);
            return brandGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<BrandListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.BrandRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<BrandListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new BrandListItemDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            var listDto = new PagenatedListDto<BrandListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, BrandPostDto brandPostDto)
        {
            Brand brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (brand is null) throw new NotFoundException("Item not found");
            if (await _unitOfWork.BrandRepository.IsExist(x => x.Id != id && x.Name.ToUpper().Trim() == brandPostDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Brand already exist");
            brand.Name = brandPostDto.Name;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Brand brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (brand is null) throw new NotFoundException("Item not found");
            brand.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
