using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Countries
{
    public class CountryForCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
