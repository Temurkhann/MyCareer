using MyCarrier.Domain.Commons;
using MyCarrier.Domain.Entities.Users;
using MyCarrier.Domain.Enums;

namespace MyCarrier.Domain.Entities.Languages
{
    public class Language : Auditable
    {
        public string Name { get; set; }
        public Level Level { get; set; }
    }
}
