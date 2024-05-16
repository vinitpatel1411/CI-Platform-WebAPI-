using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.DTO;
using WebAPI.Repositories.UserRepositories;

namespace WebAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public bool CreateUser(userRegisterDTO userRegisterDTO)
        {
            return _userRepository.CreateUser(userRegisterDTO);
        }
        public bool IsUserExist(string email)
        {
            return _userRepository.IsUserExist(email);
        }

        public userDTO login(loginDTO userLoginDTO)
        {
            User user = _userRepository.login(userLoginDTO);
            userDTO userDTO = _mapper.Map<userDTO>(user);
            return userDTO;
        }

        public bool ForgotPassword(string email)
        {
            return _userRepository.ForgotPassword(email);
        }
    }
}
