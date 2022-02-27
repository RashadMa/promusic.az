using System;
using AutoMapper;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs.BrandDto;

namespace ProMusic.Helper.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Brand, BrandGetDto>();
        }
    }
}
