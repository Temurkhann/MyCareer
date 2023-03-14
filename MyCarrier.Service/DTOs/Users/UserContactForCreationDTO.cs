using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Users
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
