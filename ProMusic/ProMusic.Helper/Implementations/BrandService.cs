using System;
using System.Threading.Tasks;
using ProMusic.Core.Entities;
using ProMusic.Data.Repositories;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.BrandDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<BrandGetDto> CreateAsync(BrandPostDto postDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagenatedListDto<BrandListItemDto>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public Task<BrandGetDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, BrandPostDto categoryPostDto)
        {
            throw new NotImplementedException();
        }
    }
}
