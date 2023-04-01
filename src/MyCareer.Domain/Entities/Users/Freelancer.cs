using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Users
{
    public class Freelancer : Auditable
    {
        [MaxLength(32)]
        public string FirstName { get; set; }

        [MaxLength(32)]
        public string LastName { get; set; }

        [MaxLength(16), Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(64)]
        public string Email { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public Position Position { get; set; }
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? ImageId { get; set; }
        public Attachment Attachment { get; set; }
    }
}