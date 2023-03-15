using MyCareer.Domain.Commons;
using MyCareer.Domain.Enums;

namespace MyCareer.Domain.Entities.Languages
{
    public class Language : Auditable
    {
        public string Name { get; set; }
        public Level Level { get; set; }
    }
}
