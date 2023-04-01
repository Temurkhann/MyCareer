using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Hobbies;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Users
{
    public class UserHobby : Auditable
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }

        [MaxLength(64)]
        public string OtherHobby { get; set; }
    }
}
