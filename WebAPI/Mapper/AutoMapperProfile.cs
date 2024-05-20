using AutoMapper;
using Data.Models;
using WebAPI.Data.DTO;

namespace WebAPI.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<userRegisterDTO, User>().ReverseMap();
            CreateMap<User,userDTO>().ReverseMap();
           
            CreateMap<cityDTO, City>().ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.id));
            CreateMap<City, cityDTO>().ForMember(dest => dest.id, opt => opt.MapFrom(src => src.CityId));

            CreateMap<countryDTO, Country>().ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.id));
            CreateMap<Country, countryDTO>().ForMember(dest => dest.id, opt => opt.MapFrom(src => src.CountryId));
        }
    }
}
