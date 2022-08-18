using System;
using AutoMapper;
using DummyAPI.Models;

namespace DummyAPI.Infrastructure
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<RoomEntity, Room>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate / 100.0m));
        }
    }
}

