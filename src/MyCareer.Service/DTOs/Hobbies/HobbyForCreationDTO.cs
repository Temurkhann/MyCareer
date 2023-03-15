using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Hobbies
{
    public class HobbyForCreationDTO
    {
        [Required]
        public string Content { get; set; }
    }
}
