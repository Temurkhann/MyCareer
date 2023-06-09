﻿using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Languages;

namespace MyCareer.Domain.Entities.Users
{
    public class UserLanguage : Auditable
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
