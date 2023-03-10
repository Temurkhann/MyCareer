using MyCarrier.Domain.Commons;
using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Freelancers
{
    public class Freelancer : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public Position Position { get; set; }
        public int ContactId { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
    }
}