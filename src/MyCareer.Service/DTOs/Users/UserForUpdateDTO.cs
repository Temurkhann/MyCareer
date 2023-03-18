using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Users
{
    public class UserForUpdateDTO
    {
        [Required]
        public string Email { get; set; }
    }
}
