using MyCareer.Domain.Commons;

namespace MyCareer.Domain.Entities.Addresses
{
    public class Address : Auditable
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public string Street { get; set; }
    }
}
