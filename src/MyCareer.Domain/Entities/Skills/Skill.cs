using MyCareer.Domain.Commons;
using MyCareer.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Skills
{
    public class Skill : Auditable
    {
        [MaxLength(64)]
        public string Content { get; set; }
        public Position Position { get; set; }
    }
}