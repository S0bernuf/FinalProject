using FinalProject.BusinessLogic.Dtos;
using FinalProject.Database.Entities;
using AutoMapper;


namespace FinalProject.BusinessLogic.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDto, Person>().ForMember(a => a.Address, b => b.MapFrom(b => b.AddressDto)).ReverseMap();
            CreateMap<UserSignupDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();

        }
    }
}
