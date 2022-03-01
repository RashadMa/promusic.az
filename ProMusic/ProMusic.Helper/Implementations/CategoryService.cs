using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.CategoryDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(CategoryPostDto postDto)
        {
            Category category = new Category
            {
                Name = postDto.Name
            };
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            category.IsDeleted = true;
            await _categoryRepository.SaveAsync();
        }

        public async Task<PagenatedListDto<CategoryListItemDto>> GetAll(int page)
        {
            var query = _categoryRepository.GetAll(x => !x.IsDeleted);
            List<CategoryListItemDto> items = query
                .Skip((page - 4) * 4)
                .Select(x => new CategoryListItemDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            var listDto = new PagenatedListDto<CategoryListItemDto>(items, query.Count(), page, 4);
            return listDto;
        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
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
            category.Name = categoryPostDto.Name;
            await _categoryRepository.SaveAsync();
        }
    }
}
