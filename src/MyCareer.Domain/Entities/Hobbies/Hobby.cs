using MyCareer.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyCareer.Domain.Entities.Hobbies
{
    public class Hobby : Auditable
    {
        [MaxLength(64)]
        public string Content { get; set; }
    }
}
