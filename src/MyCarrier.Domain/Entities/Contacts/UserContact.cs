using MyCarrier.Domain.Commons;

namespace MyCarrier.Domain.Entities.Contacts
{
    public class UserContact : Auditable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MessageText { get; set; }
        public string PhoneNumber { get; set; }
    }
}
