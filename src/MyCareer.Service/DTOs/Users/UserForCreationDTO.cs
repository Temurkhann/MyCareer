﻿using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Users
{
    public class UserForCreationDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsEmailConfirmed { get; set; }
    }
}
