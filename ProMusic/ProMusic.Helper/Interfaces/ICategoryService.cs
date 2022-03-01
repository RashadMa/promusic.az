using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.CategoryDto;

namespace ProMusic.Helper.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryPostDto postDto);
        Task UpdateAsync(int id, CategoryPostDto categoryPostDto);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<CategoryListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
