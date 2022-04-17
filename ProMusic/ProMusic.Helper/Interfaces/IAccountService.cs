using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.AccountDto;

namespace ProMusic.Helper.Interfaces
{
    public interface IAccountService
    {
        Task<AppUserGetDto> GetByIdAsync(string id);
        Task<PagenatedListDto<AppUserListItemDto>> GetAll(int page);
    }
}
