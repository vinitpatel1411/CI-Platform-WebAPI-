using WebAPI.Data.DTO;

namespace WebAPI.Services.UserServices
{
    public interface IUserService
    {
        public bool CreateUser(userRegisterDTO userRegisterDTO);
        public bool IsUserExist(string email);
        public userDTO login(loginDTO userLoginDTO);
        public bool ForgotPassword(string email);
        public userDTO UpdateUserData(userDTO userDTO);
        public bool isEmployeeIdUnique(string employeeId);
    }
}
