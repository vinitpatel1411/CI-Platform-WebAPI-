using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.DTO;
using WebAPI.Data.Models;
using WebAPI.Repositories.CommonRepositories;
using WebAPI.Repositories.UserRepositories;

namespace WebAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepository;
        public UserService(IUserRepository userRepository, IMapper mapper, ICommonRepository commonRepository) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _commonRepository = commonRepository;
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

            if (userDTO != null)
            {
                var city = _commonRepository.GetCityFromId(userDTO.CityId ?? 0);
                if (city != null)
                    userDTO.City = String.IsNullOrEmpty(city.Name) ? string.Empty : city.Name;

                var country = _commonRepository.GetCountryFromId(userDTO.CountryId ?? 0);
                if (country != null)
                    userDTO.Country = String.IsNullOrEmpty(country.Name) ? string.Empty : country.Name;
            
                return userDTO;
            }
            else
                return userDTO;
        }

        public bool ForgotPassword(string email)
        {
            return _userRepository.ForgotPassword(email);
        }

        public userDTO UpdateUserData(userDTO userDTO)
        {
            List<UserSkill> userSkills = new List<UserSkill>();
            var user = _mapper.Map<User>(userDTO);
            var updatedUser = _userRepository.UpdateUserData(user);
            
            foreach (var skills in userDTO.skills)
            {
                var userSKill = new UserSkill
                {
                    SkillId = skills.skillId,
                    userId = Convert.ToInt32(userDTO.Id),
                    CreatedAt = DateTime.Now
                };
                userSkills.Add(userSKill);
            }
            _userRepository.UpdateUserSkills(userSkills);

            var updatedUserDTO = _mapper.Map<userDTO>(updatedUser);
            if(updatedUserDTO != null)
            {
                var city = _commonRepository.GetCityFromId(updatedUserDTO.CityId ?? 0);
                if (city != null)
                    updatedUserDTO.City = String.IsNullOrEmpty(city.Name) ? string.Empty : city.Name;

                var country = _commonRepository.GetCountryFromId(updatedUserDTO.CountryId ?? 0);
                if (country != null)
                    updatedUserDTO.Country = String.IsNullOrEmpty(country.Name) ? string.Empty : country.Name;
            }
            

            return updatedUserDTO;
        }
        public bool isEmployeeIdUnique(string employeeId)
        {
            return _userRepository.isEmployeeIdUnique(employeeId);
        }

        public bool checkOldPassword(checkOldPasswordDTO model)
        {
            return _userRepository.checkOldPassword(model);
        }

        public string changePassword(changePasswordDTO model) 
        {
            return _userRepository.changePassword(model);
        }

        public userDTO GetUserDetails(string email)
        {
            var user = _userRepository.GetUserDetails(email);
            userDTO userDTO = _mapper.Map<userDTO>(user);

            if (userDTO != null)
            {
                var city = _commonRepository.GetCityFromId(userDTO.CityId ?? 0);
                if (city != null)
                    userDTO.City = String.IsNullOrEmpty(city.Name) ? string.Empty : city.Name;

                var country = _commonRepository.GetCountryFromId(userDTO.CountryId ?? 0);
                if (country != null)
                    userDTO.Country = String.IsNullOrEmpty(country.Name) ? string.Empty : country.Name;

                return userDTO;
            }
            else
                return userDTO;
        }

        public string GetUserRole(string email)
        {
            return _userRepository.GetUserRole(email);
        }

        public List<userDTO> GetUsers()
        {
            List<User> users = _userRepository.GetUserDetails();
            List<userDTO> userDTOs = _mapper.Map<List<User>,List<userDTO>>(users);

            foreach(var userDTO in userDTOs)
            {
                var city = _commonRepository.GetCityFromId(userDTO.CityId ?? 0);
                if (city != null)
                    userDTO.City = String.IsNullOrEmpty(city.Name) ? string.Empty : city.Name;

                var country = _commonRepository.GetCountryFromId(userDTO.CountryId ?? 0);
                if (country != null)
                    userDTO.Country = String.IsNullOrEmpty(country.Name) ? string.Empty : country.Name;
            }

            return userDTOs;
        }

        public userDTO UpdateUserStatus(userDTO userDTO)
        {
            var user = _userRepository.UpdateUserStatus(userDTO);
            var updatedUserDTO = _mapper.Map<userDTO>(user);
            if (updatedUserDTO != null) 
            {
                var city = _commonRepository.GetCityFromId(updatedUserDTO.CityId ?? 0);
                if (city != null)
                    updatedUserDTO.City = String.IsNullOrEmpty(city.Name) ? string.Empty : city.Name;

                var country = _commonRepository.GetCountryFromId(updatedUserDTO.CountryId ?? 0);
                if (country != null)
                    updatedUserDTO.Country = String.IsNullOrEmpty(country.Name) ? string.Empty : country.Name;
            }
            return updatedUserDTO;
        }

        public void DeleteUser(userDTO userDTO)
        {
            _userRepository.DeleteUser(userDTO);
        }

        public List<skillDTO> GetUserSkills(int userId)
        {
            return _userRepository.GetUserSkills(userId);
        }
    }
}
