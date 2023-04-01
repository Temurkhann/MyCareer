using MyCareer.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Contacts
{
    public class Contact : Auditable
    {
        [MaxLength(64)]
        public string WhatsApp { get; set; }

        [MaxLength(64)]
        public string Facebook { get; set; }
        
        [MaxLength(64)]
        public string Twitter { get; set; }
        
        [MaxLength(64)]
        public string Instagram { get; set; }
        
        [MaxLength(64)]
        public string Telegram { get; set; }
        
        [MaxLength(64)]
        public string Github { get; set; }
    }
}
