using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.ProductDto;

namespace ProMusic.Helper.Interfaces
{
    public interface IProductService
    {
        Task<ProductGetDto> CreateAsync(ProductPostDto postDto);
        Task UpdateAsync(int id, ProductPostDto productPostDto);
        Task<ProductGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<ProductListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
