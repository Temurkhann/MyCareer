﻿using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Users;
using MyCareer.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Educations
{
    public class Education : Auditable
    {
        [MaxLength(64)]
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
