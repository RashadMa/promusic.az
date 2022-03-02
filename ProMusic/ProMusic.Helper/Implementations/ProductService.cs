using System;
using System.Threading.Tasks;
using ProMusic.Core;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.ProductDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ProductPostDto> CreateAsync(ProductPostDto postDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagenatedListDto<ProductListItemDto>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public Task<ProductPostDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, ProductPostDto productPostDto)
        {
            throw new NotImplementedException();
        }
    }
}
