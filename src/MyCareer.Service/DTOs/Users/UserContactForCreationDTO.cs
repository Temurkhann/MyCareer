using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Users
{
    public class UserContactForCreationDTO
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string MessageText { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
    }
}
