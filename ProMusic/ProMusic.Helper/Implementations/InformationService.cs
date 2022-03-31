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
using ProMusic.Helper.DTOs.InformationDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class InformationService : IInformationService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InformationService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<InformationGetDto> CreateAsync(InformationPostDto postDto)
        {
            string fileName = "";
            if (postDto.Photo != null)
            {
                fileName = postDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(postDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/information", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    postDto.Photo.CopyTo(stream);
                }
            }

            Information information = _mapper.Map<Information>(postDto);
            await _unitOfWork.InformationRepository.AddAsync(information);
            await _unitOfWork.SaveAsync();
            return new InformationGetDto
            {
                Title = information.Title,
                Desc = information.Desc,
                Image = information.Image,
            };
        }

        #endregion

        #region Get

        public async Task<InformationGetDto> GetByIdAsync(int id)
        {
            Information information = await _unitOfWork.InformationRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (information is null) throw new NotFoundException("Item not found");
            InformationGetDto informationGetDto = _mapper.Map<InformationGetDto>(information);
            return informationGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<InformationListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.InformationRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<InformationListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new InformationListItemDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    Desc = x.Desc,
                })
                .ToList();

            var listDto = new PagenatedListDto<InformationListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, InformationPostDto informationPostDto)
        {
            Information information = await _unitOfWork.InformationRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (information is null) throw new NotFoundException("Item not found");
            information.Title = informationPostDto.Title;
            information.Desc = informationPostDto.Desc;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Information information = await _unitOfWork.InformationRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (information is null) throw new NotFoundException("Item not found");
            information.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
