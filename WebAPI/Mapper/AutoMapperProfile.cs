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
        }
    }
}
