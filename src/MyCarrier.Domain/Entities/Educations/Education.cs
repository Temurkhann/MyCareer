using MyCarrier.Domain.Commons;
using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarrier.Domain.Entities.Users;

namespace MyCarrier.Domain.Entities.Educations
{
    public class Education : Auditable
    {
        public string Name { get; set; }
        public Degree Degree { get; set; }
        public TypeOfStudy TypeOfStudy { get; set; }
        public string Location { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
