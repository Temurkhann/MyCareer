using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Addresses
{
    public class AddressForCreationDTO
    {
        [Required]
        public int CountryId { get; set; }

        [Required]
        public int RegionId { get; set; }

        [Required]
        public string Street { get; set; }
    }
}
