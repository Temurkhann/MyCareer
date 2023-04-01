using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Users
{
    public class UserForCreationDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
