using AutoMapper;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using WebAPI.Data;
using WebAPI.Data.DTO;
using WebAPI.Repositories.CommonRepositories;

namespace WebAPI.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DefaultContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepository;

        public UserRepository(DefaultContext context, IMapper mapper, ICommonRepository commonRepository)
        {
            _context = context;
            _mapper = mapper;
            _commonRepository = commonRepository;
        }
        public bool CreateUser(userRegisterDTO userRegisterDTO)
        {
            try
            {
                User user = _mapper.Map<User>(userRegisterDTO);
                user.Createdate = DateTime.Now.ToUniversalTime();
                string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(userRegisterDTO.Password);
                user.Password = encryptedPassword;

                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public bool IsUserExist(string email)
        {
            var user = _context.Users.Where(x=>x.Email == email).FirstOrDefault();
            if(user == null)
                return false;
            else 
                return true;
        }

        public User login(loginDTO userLogin) 
        {
            bool verified = false;
            var user = _context.Users.Where(u => u.Email == userLogin.email).FirstOrDefault();
            if (user != null)
            {
                verified = BCrypt.Net.BCrypt.Verify(userLogin.password, user.Password);
                if (verified)
                    return user;
            }
            return null;
        }

        public bool ForgotPassword(string email)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email.Equals(email));
            if (user != null)
            {
                ResetPassword resetPassword = new()
                {
                    UserId = user.Id,
                    Token = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                };

                _context.ResetPasswords.Add(resetPassword);
                _context.SaveChanges();

                string subject = "Reset Your Password";
                string mailBody = @"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;'>
                <h4>Hi " + user.Firstname + " " + user.Lastname + @",</h4>
                <p>You recently requested to reset your password for your account. Use the button below to reset it. This password reset is only valid for the next 30 Minutes.</p><br><br>
                <a style='background-color: #007bff; color: #fff; border: none; padding: 10px 20px; border-radius: 5px; text-decoration: none; cursor: pointer;' href='" + "http://localhost:4200/reset-password/" + resetPassword.Token + @"'>Reset your password</a>
                <br><br>
                <p>If you did not request for a password reset, please ignore this email.</p>
                <p>Thanks,</p>
                <p>The Team</p>
                </div>";

                Helper.SendEmail(mailBody, subject, user.Email);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User UpdateUserData(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();

            return _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
        }

        public bool isEmployeeIdUnique(string employeeId)
        {
            var user = _context.Users.Where(x=>x.Employeeid == employeeId).FirstOrDefault();
            if (user != null)
                return false;
            else
                return true;
        }
    }
}
