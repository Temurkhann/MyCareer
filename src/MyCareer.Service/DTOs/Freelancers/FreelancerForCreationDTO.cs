using MyCareer.Domain.Enums;
using MyCareer.Service.DTOs.Addresses;
using MyCareer.Service.DTOs.Attachments;
using MyCareer.Service.DTOs.Contacts;
using MyCareer.Service.DTOs.Users;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Freelancers
{
    public abstract class FreelancerForCreationDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public AddressForCreationDTO Address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public Position Position { get; set; }

        public ContactForCreationDTO Contact { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
