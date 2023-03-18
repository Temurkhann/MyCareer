using MyCareer.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Languages
{
    public class LanguageForCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public Level Level { get; set; }
    }
}
