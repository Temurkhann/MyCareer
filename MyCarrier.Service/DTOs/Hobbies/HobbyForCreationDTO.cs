using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Hobbies
{
    public class HobbyForCreationDTO
    {
        [Required]
        public string Content { get; set; }
    }
}
