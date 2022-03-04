using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.CategoryDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto)
        {
            if (await _unitOfWork.CategoryRepository.IsExist(x => x.Name.ToUpper().Trim() == postDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Category already exist");
            Category category = _mapper.Map<Category>(postDto);
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new CategoryGetDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        #endregion

        #region Get

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);
            return categoryGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<CategoryListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.CategoryRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<CategoryListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CategoryListItemDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            var listDto = new PagenatedListDto<CategoryListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, CategoryPutDto categoryPutDto)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            if (await _unitOfWork.CategoryRepository.IsExist(x => x.Id != id && x.Name.ToUpper().Trim() == categoryPutDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Category already exist");
            category.Name = categoryPutDto.Name;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            category.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
