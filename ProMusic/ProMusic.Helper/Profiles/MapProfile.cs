using System;
using AutoMapper;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs.BrandDto;
using ProMusic.Helper.DTOs.CategoryDto;
using ProMusic.Helper.DTOs.InformationDto;
using ProMusic.Helper.DTOs.ProductDto;
using ProMusic.Helper.DTOs.SliderDto;

namespace ProMusic.Helper.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            #region Product

            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductPostDto, Product>();
            CreateMap<Product, ProductListItemDto>();

            #endregion

            #region Category

            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category, CategoryListItemDto>();

            #endregion

            #region Brand

            CreateMap<Brand, BrandGetDto>();
            CreateMap<BrandPostDto, Brand>();
            CreateMap<Brand, BrandListItemDto>();

            #endregion

            #region Slider

            CreateMap<Slider, SliderGetDto>();
            CreateMap<SliderPostDto, Slider>();
            CreateMap<Slider, SliderListItemDto>();

            #endregion

            #region Information

            CreateMap<Information, InformationGetDto>();
            CreateMap<InformationPostDto, Information>();
            CreateMap<Information, InformationListItemDto>();

            #endregion
        }
    }
}
