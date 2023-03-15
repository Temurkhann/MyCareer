using System;
using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Users;

namespace MyCareer.Domain.Entities.Experiences
{
    public class Experience : Auditable
    {
        public string CompanyName { get; set; }
        public string Job { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
