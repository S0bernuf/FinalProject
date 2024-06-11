using FinalProject.BusinessLogic.Dtos;
using FinalProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace FinalProject.BusinessLogic.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDto, Person>().ReverseMap();
            CreateMap<UserSignupDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
