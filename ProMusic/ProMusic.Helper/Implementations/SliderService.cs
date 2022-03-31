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
using ProMusic.Helper.DTOs.SliderDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SliderService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<SliderGetDto> CreateAsync(SliderPostDto postDto)
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

                string path = Path.Combine(_env.WebRootPath, "images/slider", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    postDto.Photo.CopyTo(stream);
                }
            }

            Slider slider = _mapper.Map<Slider>(postDto);
            await _unitOfWork.SliderRepository.AddAsync(slider);
            await _unitOfWork.SaveAsync();
            return new SliderGetDto
            {
                Id = slider.Id,
                Title = slider.Title,
                BtnText = slider.BtnText,
                BtnUrl = slider.BtnUrl,
                Order = slider.Order,
                IsDeleted = slider.IsDeleted,
                Image = slider.Image,
            };
        }

        #endregion

        #region Get

        public async Task<SliderGetDto> GetByIdAsync(int id)
        {
            Slider slider = await _unitOfWork.SliderRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (slider is null) throw new NotFoundException("Item not found");
            SliderGetDto sliderGetDto = _mapper.Map<SliderGetDto>(slider);
            return sliderGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<SliderListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.SliderRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<SliderListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new SliderListItemDto
                {
                    Id = x.Id,
                    Image = x.Image,
                    Title = x.Title,
                    BtnUrl = x.BtnUrl,
                    BtnText = x.BtnText,
                    Order = x.Order,
                })
                .ToList();

            var listDto = new PagenatedListDto<SliderListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, SliderPostDto sliderPostDto)
        {
            Slider slider = await _unitOfWork.SliderRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (slider is null) throw new NotFoundException("Item not found");

            Slider oldSlider = await _unitOfWork.SliderRepository.GetAsync(x => x.Id == id);
            if (oldSlider is null) throw new NotFoundException("item not found");

            if (oldSlider.Image != null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images/slider", oldSlider.Image);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            string fileName = "";
            if (sliderPostDto.Photo != null)
            {
                fileName = sliderPostDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(sliderPostDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/slider", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    sliderPostDto.Photo.CopyTo(stream);
                }
            }

            slider.Title = sliderPostDto.Title;
            slider.BtnText = sliderPostDto.BtnText;
            slider.BtnUrl = sliderPostDto.BtnUrl;
            slider.Order = sliderPostDto.Order;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Slider slider = await _unitOfWork.SliderRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (slider is null) throw new NotFoundException("Item not found");
            slider.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
