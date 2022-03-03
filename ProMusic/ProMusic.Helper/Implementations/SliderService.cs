using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SliderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<SliderGetDto> CreateAsync(SliderPostDto postDto)
        {
            Slider slider = _mapper.Map<Slider>(postDto);
            await _unitOfWork.SliderRepository.AddAsync(slider);
            await _unitOfWork.SaveAsync();
            return new SliderGetDto
            {
                Id = slider.Id,
                Title1 = slider.Title1,
                Title2 = slider.Title2,
                Desc = slider.Desc,
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
                    Title1 = x.Title1,
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
            slider.Title1 = sliderPostDto.Title1;
            slider.Title2 = sliderPostDto.Title2;
            slider.Desc = sliderPostDto.Desc;
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
