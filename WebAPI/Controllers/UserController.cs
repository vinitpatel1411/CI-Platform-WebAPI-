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
    }
}
