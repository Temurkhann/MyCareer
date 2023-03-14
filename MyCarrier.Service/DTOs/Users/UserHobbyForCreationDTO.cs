using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Users
{
    public class UserHobbyForCreationDTO
    {
        public int UserId { get; set; }
        public int HobbyId { get; set; }
        public string OtherHobby { get; set; }
    }
}
