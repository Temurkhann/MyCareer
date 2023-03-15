using MyCareer.Domain.Commons;
using MyCareer.Domain.Enums;

namespace MyCareer.Domain.Entities.Skills
{
    public class Skill : Auditable
    {
        public string Content { get; set; }
        public Position Position { get; set; }
    }
}
