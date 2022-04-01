using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.SettingDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SettingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<SettingGetDto> CreateAsync(SettingPostDto postDto)
        {
            Setting setting = _mapper.Map<Setting>(postDto);
            await _unitOfWork.SettingRepository.AddAsync(setting);
            await _unitOfWork.SaveAsync();
            return new SettingGetDto
            {
                Key = setting.Key,
                Value = setting.Value
            };
        }

        #endregion

        #region Get

        public async Task<SettingGetDto> GetByIdAsync(int id)
        {
            Setting setting = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == id);
            if (setting is null) throw new NotFoundException("Item not found");
            SettingGetDto settingGetDto = _mapper.Map<SettingGetDto>(setting);
            return settingGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<SettingListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.SettingRepository.GetAll(x=> !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<SettingListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new SettingListItemDto
                {
                    Key = x.Key,
                    Value = x.Value
                })
                .ToList();

            var listDto = new PagenatedListDto<SettingListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, SettingPostDto settingPostDto)
        {
            Setting setting = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (setting is null) throw new NotFoundException("Item not found");
            setting.Key = settingPostDto.Key;
            setting.Value = settingPostDto.Value;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Setting setting = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (setting is null) throw new NotFoundException("Item not found");
            setting.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
