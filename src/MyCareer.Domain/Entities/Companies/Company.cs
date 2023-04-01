using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Companies
{
    public class Company : Auditable
    {
        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        [MaxLength(64), Phone]
        public string PhoneNumber { get; set; }
        public int? ImageId { get; set; }
        public Attachment Image { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CompanyInformationId { get; set; }
        public CompanyInformation CompanyInformation { get; set; }
    }
}
