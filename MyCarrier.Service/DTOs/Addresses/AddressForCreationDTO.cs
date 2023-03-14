using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Addresses
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
