using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SettingService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<SettingGetDto> CreateAsync(SettingPostDto postDto)
        {
            //string fileName = "";
            //if (postDto.Photo != null)
            //{
            //    fileName = postDto.Photo.FileName;


            //    if (fileName.Length > 100)
            //    {
            //        fileName = fileName.Substring(postDto.Photo.FileName.Length - 64, 64);
            //    }

            //    //string name = DateTime.Now.Second.ToString() + (fileName);

            //    string path = Path.Combine(_env.WebRootPath, "images/settings", fileName);

            //    using (FileStream stream = new FileStream(path, FileMode.Create))
            //    {
            //        postDto.Photo.CopyTo(stream);
            //    }
            //}

            Setting setting = _mapper.Map<Setting>(postDto);
            await _unitOfWork.SettingRepository.AddAsync(setting);
            await _unitOfWork.SaveAsync();
            return new SettingGetDto
            {
                Key = setting.Key,
                Value = setting.Value,
                //Image = setting.Image,
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
            var query = _unitOfWork.SettingRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<SettingListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new SettingListItemDto
                {
                    Key = x.Key,
                    Value = x.Value,
                    Image = x.Image,
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
            //Setting old = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == id);
            //if (old is null) throw new NotFoundException("item not found");

            //if (old.Image != null)
            //{
            //    string oldPath = Path.Combine(_env.WebRootPath, "images/settings", old.Image);

            //    if (System.IO.File.Exists(oldPath))
            //    {
            //        System.IO.File.Delete(oldPath);
            //    }
            //}

            //string fileName = "";
            //if (settingPostDto.Photo != null)
            //{
            //    fileName = settingPostDto.Photo.FileName;


            //    if (fileName.Length > 100)
            //    {
            //        fileName = fileName.Substring(settingPostDto.Photo.FileName.Length - 64, 64);
            //    }

            //    //string name = DateTime.Now.Second.ToString() + (fileName);

            //    string path = Path.Combine(_env.WebRootPath, "images/settings", fileName);

            //    using (FileStream stream = new FileStream(path, FileMode.Create))
            //    {
            //        settingPostDto.Photo.CopyTo(stream);
            //    }
            //}
            setting.Key = settingPostDto.Key;
            setting.Value = settingPostDto.Value;
            //setting.Image = fileName;
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
