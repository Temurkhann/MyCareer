using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Regions
{
    public class RegionForCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
