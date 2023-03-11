﻿using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarrier.Domain.Entities.Hobbies;

namespace MyCarrier.Domain.Entities.Users
{
    public class UserHobby : Auditable
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }
        public string OtherHobby { get; set; }
    }
}
