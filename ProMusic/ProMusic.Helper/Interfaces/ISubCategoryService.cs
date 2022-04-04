using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.SubCategoryDto;

namespace ProMusic.Helper.Interfaces
{
    public interface ISubCategoryService
    {
        Task<SubCategoryGetDto> CreateAsync(SubCategoryPostDto postDto);
        Task UpdateAsync(int id, SubCategoryPostDto subCategoryPosttDto);
        Task<SubCategoryGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<SubCategoryListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
