using AutoMapper;
using Data.Models;
using System.Globalization;
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

            CreateMap<skillDTO, Skill>().ReverseMap();

            CreateMap<missionThemeDTO,MissionTheme>().ForMember(dest => dest.MissionThemeId, opt=> opt.MapFrom(src => src.id))
                .ReverseMap()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.MissionThemeId));

            CreateMap<missionDTO, Mission>()
             .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.startDate, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)))
             .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.endDate, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)))
             .ForMember(dest => dest.RegistrationDeadlineDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.registrationDeadlineDate, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)))
             .ReverseMap()
             .ForMember(dest => dest.startDate, opt => opt.MapFrom(src => src.StartDate.HasValue ? src.StartDate.Value.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : null))
             .ForMember(dest => dest.endDate, opt => opt.MapFrom(src => src.EndDate.HasValue ? src.EndDate.Value.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : null))
             .ForMember(dest => dest.registrationDeadlineDate, opt => opt.MapFrom(src => src.RegistrationDeadlineDate.HasValue ? src.RegistrationDeadlineDate.Value.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : null));
        }
    }
}
