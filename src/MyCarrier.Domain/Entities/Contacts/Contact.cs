using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Contacts
{
    public class Contact : Auditable
    {
        public string WhatsApp { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Telegram { get; set; }
        public string Github { get; set; }
    }
}
