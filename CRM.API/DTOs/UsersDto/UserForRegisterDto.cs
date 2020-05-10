using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }
        
        [Required]
        public string Gender { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime LastActive { get; set; }
        
        [Required]
        public string Country { get; set; }
        
        [Required]
        public string City { get; set; }
        
        public UserForRegisterDto()
        {
            CreatedAt = DateTime.Now;
            LastActive = DateTime.Now;
        }

    }
}