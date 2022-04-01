using System;
using AutoMapper;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs.BrandDto;
using ProMusic.Helper.DTOs.CategoryDto;
using ProMusic.Helper.DTOs.InformationDto;
using ProMusic.Helper.DTOs.ProductDto;
using ProMusic.Helper.DTOs.SettingDto;
using ProMusic.Helper.DTOs.SliderDto;

namespace ProMusic.Helper.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Product

            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductPostDto, Product>().ForMember(x => x.Image, y => y.MapFrom(x => x.Photo.FileName));
            CreateMap<ProductPutDto, Product>().ForMember(x => x.Image, y => y.MapFrom(x => x.Photo.FileName));
            CreateMap<Product, ProductListItemDto>();
            CreateMap<Product, ProductDto>();

            #endregion

            #region Category

            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>().ForMember(x => x.Image, y => y.MapFrom(x => x.Photo.FileName));
            CreateMap<CategoryPutDto, Category>().ForMember(x => x.Image, y => y.MapFrom(x => x.Photo.FileName));
            CreateMap<Category, CategoryListItemDto>();
            CreateMap<Category, CategoryDto>();

            #endregion

            #region Brand

            CreateMap<Brand, BrandGetDto>();
            CreateMap<BrandPostDto, Brand>().ForMember(x => x.Image, y => y.MapFrom(x => x.Photo.FileName));
            CreateMap<BrandPutDto, Brand>().ForMember(x => x.Image, y => y.MapFrom(x => x.Photo.FileName));
            CreateMap<Brand, BrandListItemDto>();
            CreateMap<Brand, BrandDto>();

            #endregion

            #region Slider

            CreateMap<Slider, SliderGetDto>();
            CreateMap<SliderPostDto, Slider>().ForMember(x => x.Image, y => y.MapFrom(x => x.Photo.FileName));
            CreateMap<Slider, SliderListItemDto>();
            CreateMap<Slider, SliderDto>();

            #endregion

            #region Information

            CreateMap<Information, InformationGetDto>();
            CreateMap<InformationPostDto, Information>().ForMember(x => x.Image, y => y.MapFrom(x => x.Photo.FileName));
            CreateMap<Information, InformationListItemDto>();
            CreateMap<Information, InformationDto>();

            #endregion

            #region Setting

            CreateMap<Setting, SettingGetDto>();
            CreateMap<SettingPostDto, Setting>();//.ForMember(x => x.Image, y => y.MapFrom(x => x.Photo.FileName));
            CreateMap<Setting, SettingListItemDto>();

            #endregion
        }
    }
}
