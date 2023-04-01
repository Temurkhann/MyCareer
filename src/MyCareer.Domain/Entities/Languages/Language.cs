using MyCareer.Domain.Commons;
using MyCareer.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Languages
{
    public class Language : Auditable
    {
        [MaxLength(32)]
        public string Name { get; set; }
        public Level Level { get; set; }
    }
}
