using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Contacts;

namespace MyCareer.Domain.Entities.Companies
{
    public class CompanyInformation : Auditable
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string  Description { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
