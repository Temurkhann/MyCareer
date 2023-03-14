using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Freelancers
{
    public class FreelancerForCreationDTO
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
        public int AddressId { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        public int ContactId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ImageId { get; set; }
    }
}
