using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Contacts;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Companies
{
    public class CompanyInformation : Auditable
    {
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(16), Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(64)]
        public string Location { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
