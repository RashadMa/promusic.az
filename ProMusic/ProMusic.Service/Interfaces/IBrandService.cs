using System;
using System.Threading.Tasks;
using ProMusic.Service.DTOs;
using ProMusic.Service.DTOs.BrandDto;

namespace ProMusic.Service.Interfaces
{
    public interface IBrandService
    {
        Task<BrandGetDto> CreateAsync(BrandPostDto postDto);
        Task UpdateAsync(int id, BrandPostDto brandPostDto);
        Task<BrandGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<BrandListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
