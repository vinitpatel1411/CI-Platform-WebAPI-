using Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.DTO
{
    public class userDTO
    {
        public long Id { get; set; }
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(128)]
        public string Email { get; set; } = null!;
        [StringLength(255)]
        public string Password { get; set; } = null!;
        [StringLength(256)]
        public string PhoneNumber { get; set; } = null!;
        [StringLength(2048)]
        public string? Avatar { get; set; }
        public string? WhyIVolunteer { get; set; }
        [StringLength(50)]
        public string? EmployeeId { get; set; }
        [StringLength(50)]
        public string? Department { get; set; }
        public long? CityId { get; set; }
        public string? City { get; set; }
        public long? CountryId { get; set; }
        public string? Country { get; set; }
        public string? ProfileText { get; set; }
        [StringLength(255)]
        public string? LinkedInUrl { get; set; }
        [StringLength(255)]
        public string? Title { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? Availablity { get; set; }
        public string? manager { get; set; }
        public string? Role { get; set; }
    }
}
