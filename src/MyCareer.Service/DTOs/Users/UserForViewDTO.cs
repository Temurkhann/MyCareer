using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.DTOs.Users
{
    public class UserForViewDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public bool IsEmailConfirmed { get; set; }
    }
}
