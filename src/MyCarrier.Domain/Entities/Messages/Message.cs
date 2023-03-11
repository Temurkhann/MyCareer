using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Messages
{
    public class Message : Auditable
    {
        public int ChatId { get; set; }
        public string Media { get; set; }
        public string Content { get; set; }
    }
}
