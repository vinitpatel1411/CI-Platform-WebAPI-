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
        public bool checkOldPassword(checkOldPasswordDTO model);
        public string changePassword(changePasswordDTO model);
        public userDTO GetUserDetails(string email);
        public string GetUserRole(string email);
        public List<userDTO> GetUsers();
        public userDTO UpdateUserStatus(userDTO userDTO);
        public void DeleteUser(userDTO userDTO);
        public List<skillDTO> GetUserSkills(int userId);
    }
}
