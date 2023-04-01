using MyCareer.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Addresses
{
    public class Country : Auditable
    {
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
