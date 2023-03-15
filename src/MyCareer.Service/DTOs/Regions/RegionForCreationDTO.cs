using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Regions
{
    public class RegionForCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
