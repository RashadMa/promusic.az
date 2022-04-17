using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.AccountDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Get

        public async Task<AppUserGetDto> GetByIdAsync(string id)
        {
            AppUser user = await _unitOfWork.AccountRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (user is null) throw new NotFoundException("Item not found");
            AppUserGetDto userGetDto = _mapper.Map<AppUserGetDto>(user);
            return userGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<AppUserListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.AccountRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);

            List<AppUserListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new AppUserListItemDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                })
                .ToList();

            var listDto = new PagenatedListDto<AppUserListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion
    }
}
