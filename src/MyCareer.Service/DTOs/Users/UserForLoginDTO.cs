using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Users
{
    public class UserForLoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
