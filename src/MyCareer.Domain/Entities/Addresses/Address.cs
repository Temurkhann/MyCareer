using MyCareer.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyCareer.Domain.Entities.Addresses
{
    public class Address : Auditable
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }

        [MaxLength(64)]
        public string Street { get; set; }
    }
}
