using AutoMapper;
using London_Api_corePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace London_Api_corePractice.InfraStructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomEntity, Room>().ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate / 100.0m));
        }
    }
}
