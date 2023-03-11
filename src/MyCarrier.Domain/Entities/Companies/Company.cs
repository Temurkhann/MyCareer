using MyCarrier.Domain.Commons;

using MyCarrier.Domain.Entities.Attachments;
using MyCarrier.Domain.Entities.Contacts;
using MyCarrier.Domain.Entities.Users;

namespace MyCarrier.Domain.Entities.Companies
{
    public class Company : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int ImageId { get; set; }
        public Attachment Image { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public int CompanyInformationId { get; set; }
        public  CompanyInformation CompanyInformation { get; set; }
    }
}
