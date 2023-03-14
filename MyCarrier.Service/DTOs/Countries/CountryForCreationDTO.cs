using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Countries
{
    public class CountryForCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
