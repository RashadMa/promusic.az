using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.InformationDto;

namespace ProMusic.Helper.Interfaces
{
    public interface IInformationService
    {
        Task<InformationGetDto> CreateAsync(InformationPostDto postDto);
        Task UpdateAsync(int id, InformationPostDto informationPostDto);
        Task<InformationGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<InformationListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
