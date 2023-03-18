using AutoMapper;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Addresses;
using MyCareer.Service.DTOs.Regions;
using MyCareer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // user 
            CreateMap<User, UserForCreationDTO>().ReverseMap();

        }
    }
}