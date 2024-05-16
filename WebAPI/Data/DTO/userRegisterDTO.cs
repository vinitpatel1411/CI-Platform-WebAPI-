using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.DTO
{
    public class userRegisterDTO
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public long Phonenumber { get; set; }
    }
}
