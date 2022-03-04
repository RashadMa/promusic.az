using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.BrandDto;

namespace ProMusic.Helper.Interfaces
{
    public interface IBrandService
    {
        Task<BrandGetDto> CreateAsync(BrandPostDto postDto);
        Task UpdateAsync(int id, BrandPutDto brandPutDto);
        Task<BrandGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<BrandListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
