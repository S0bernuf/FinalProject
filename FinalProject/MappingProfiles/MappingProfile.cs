using FinalProject.BusinessLogic.Dtos;
using FinalProject.Database.Entities;
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
