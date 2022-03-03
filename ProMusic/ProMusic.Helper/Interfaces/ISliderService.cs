using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.SliderDto;

namespace ProMusic.Helper.Interfaces
{
    public interface ISliderService
    {
        Task<SliderGetDto> CreateAsync(SliderPostDto postDto);
        Task UpdateAsync(int id, SliderPostDto sliderPostDto);
        Task<SliderGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<SliderListItemDto>> GetAll(int page);
        Task Delete(int id);
    }
}
