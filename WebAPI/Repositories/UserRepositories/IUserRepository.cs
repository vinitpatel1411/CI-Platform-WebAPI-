using Data.Models;
using WebAPI.Data.DTO;

namespace WebAPI.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        public bool CreateUser(userRegisterDTO userRegisterDTO);
        bool IsUserExist(string email);
        public User login(loginDTO userLogin);
        public bool ForgotPassword(string email);
        public User UpdateUserData(User user);
        public bool isEmployeeIdUnique(string employeeId);
        public bool checkOldPassword(checkOldPasswordDTO model);
        public string changePassword(changePasswordDTO model);
    }
}
