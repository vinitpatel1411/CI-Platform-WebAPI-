using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Common;
using WebAPI.Data;
using WebAPI.Data.DTO;
using WebAPI.Services.UserServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IConfiguration config) 
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult RegisterUser(userRegisterDTO userRegisterDTO)
        {
            bool user = _userService.CreateUser(userRegisterDTO);
            return user
               ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }))
               : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpGet]
        [Route("IsUserExist")]
        public ActionResult IsUserExist(string? email)
        {
            var user = _userService.IsUserExist(email);
            return user
               ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }))
               : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.USER_NOT_FOUND }));
        }

        [HttpPost("Login")]
        public ActionResult Login(loginDTO userLogin)
        {
            userDTO user = _userService.login(userLogin);
            return user != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, new { token = Helper.GenerateToken(user, _config), data = user }))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.USER_NOT_FOUND }));
        }

        [HttpGet("ForgotPassword")]
        public ActionResult ForgotPassword(string email)
        {
            bool result = _userService.ForgotPassword(email);
            return result
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.RESET_PASSWORD_EMAIL_SUCCESS }))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.USER_NOT_FOUND }));
        }

        [HttpPost]
        [Route("updateUser")]
        public ActionResult UpdateUserData(userDTO userDTO)
        {
            var updatedUserDTO = _userService.UpdateUserData(userDTO);

            return updatedUserDTO != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.UPDATE_USER_DATA_SUCCESS }, updatedUserDTO))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpGet]
        [Route("isEmployeeIdUnique")]
        public ActionResult isEmployeeIdUnique(string employeeId)
        {
            return _userService.isEmployeeIdUnique(employeeId) 
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }))
               : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.EMPLOYEEID_IS_NOT_UNIQUE }));
        }

        [HttpPost]
        [Route("checkOldPassword")]
        public ActionResult checkOldPassword(checkOldPasswordDTO checkOldPassword)
        {
            return _userService.checkOldPassword(checkOldPassword)
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }))
               : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.OLD_PASSWORD_NOT_CORRECT }));
        }

        [HttpPost]
        [Route("changePassword")]
        public ActionResult changePassword(changePasswordDTO changePassword) 
        {
            string updatedPassword = _userService.changePassword(changePassword);
            return updatedPassword != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, updatedPassword))
               : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpGet]
        [Route("userDetails/{email}")]
        public ActionResult GetUserDetails(string email)
        {
            var user = _userService.GetUserDetails(email);
            return user != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, user))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpGet]
        [Route("getUserRole/{email}")]
        public ActionResult GetUserRole(string email)
        {
            var userRole = _userService.GetUserRole(email);
            return userRole != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, userRole))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpGet]
        [Route("getUsers")]
        public ActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return users != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, users))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpPost]
        [Route("updateUserStatus")]
        public ActionResult UpdateUserStatus(userDTO userDTO)
        {
            var user = _userService.UpdateUserStatus(userDTO);
            return user != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, user))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpDelete]
        [Route("deleteUser")]
        public ActionResult DeleteUser(userDTO userDTO) 
        {
            try
            {
                _userService.DeleteUser(userDTO);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch(Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
            }
        }
    }
}
