using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISettingRepository _settingRepository;

        public CategoryService(ICategoryRepository categoryRepository, ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto)
        {
            if (await _categoryRepository.IsExist(x => x.Name.ToUpper().Trim() == postDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Category already exist");
            Category category = new Category
            {
                Name = postDto.Name
            };
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
            return new CategoryGetDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task Delete(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            category.IsDeleted = true;
            await _categoryRepository.SaveAsync();
        }

        public async Task<PagenatedListDto<CategoryListItemDto>> GetAll(int page)
        {
            var query = _categoryRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _settingRepository.GetValueAsync("PageSize");
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

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            CategoryGetDto categoryGetDto = new CategoryGetDto
            {
                Id = category.Id,
                Name = category.Name,
            };
            return categoryGetDto;
        }

        public async Task UpdateAsync(int id, CategoryPostDto categoryPostDto)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            if (await _categoryRepository.IsExist(x => x.Id != id && x.Name.ToUpper().Trim() == categoryPostDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Category already exist");
            category.Name = categoryPostDto.Name;
            await _categoryRepository.SaveAsync();
        }
    }
}
