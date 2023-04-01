using MyCareer.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Users
{
    public class User : Auditable
    {
        [MaxLength(64)]
        public string Email { get; set; }

        [MaxLength(64)]
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }

    }
}
