using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Users
{
    public class UserForUpdateDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
