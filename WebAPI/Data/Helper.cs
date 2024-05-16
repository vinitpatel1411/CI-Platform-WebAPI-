using Data.Models;
using MailKit.Security;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using WebAPI.Data.DTO;

namespace WebAPI.Data
{
    public class Helper
    {
        public static string GenerateToken(userDTO user, IConfiguration _config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Email),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(240),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static void SendEmail(string body, string subject, string email)
        {
            //MimeMessage mimeMessage = new();
            //mimeMessage.From.Add(MailboxAddress.Parse("vinit.patel@tatvasoft.com"));
            //mimeMessage.To.Add(MailboxAddress.Parse(email));
            //mimeMessage.Subject = subject;
            //mimeMessage.Body = new TextPart(TextFormat.Html) { Text = body };

            // send email
            //using var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate("vinit.patel@tatvasoft.com", "abcd");
            //smtp.Send(mimeMessage);
            //smtp.Disconnect(true);

            var message = new MailMessage();
            message.From = new MailAddress("vinit.patel@tatvasoft.com");
            message.To.Add(email);
            message.Subject = subject;
            message.Body = body;

            using var client = new SmtpClient("smtp.office365.com", 587);
            client.EnableSsl = true; // Enable SSL/TLS
            client.UseDefaultCredentials = false; // Ensure we use explicit credentials
            client.Credentials = new NetworkCredential("vinit.patel@tatvasoft.com", "abcdef");

            client.Send(message);

        }

    }
}
