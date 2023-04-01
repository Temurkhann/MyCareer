using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Users;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Experiences
{
    public class Experience : Auditable
    {
        [MaxLength(64)]
        public string CompanyName { get; set; }

        [MaxLength(64)]
        public string Job { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
