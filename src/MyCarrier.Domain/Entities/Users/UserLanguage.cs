﻿using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Users
{
    public class UserLanguage : Auditable
    {
        public int LanguageId { get; set; }
        public int UserId { get; set; }
    }
}
