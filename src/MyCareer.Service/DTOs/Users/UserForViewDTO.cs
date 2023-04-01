using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Users
{
    public class UserForViewDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool IsEmailConfirmed { get; set; }
    }
}
