using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Messages
{
    public class MessageForCreationDTO
    {
        public int ChatId { get; set; }
        public string Media { get; set; }
        public string Content { get; set; }
    }
}
