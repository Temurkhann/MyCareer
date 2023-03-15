using System;
using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Users;
using MyCareer.Domain.Enums;

namespace MyCareer.Domain.Entities.Educations
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
