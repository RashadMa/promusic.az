using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.SettingDto;

namespace ProMusic.Helper.Interfaces
{
    public interface ISettingService
    {
        Task UpdateAsync(int id, SettingPostDto settingPostDto);
        Task<SettingGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<SettingListItemDto>> GetAll(int page);
    }
}
