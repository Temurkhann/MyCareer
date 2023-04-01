using MyCareer.Domain.Commons;
using MyCareer.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Jobs
{
    public class Job : Auditable
    {
        [MaxLength(64)]
        public string Name { get; set; }
        
        [MaxLength(64)]
        public string Description { get; set; }

        [MaxLength(64)]
        public string CompanyName { get; set; }
        public RequiredLevel RequiredLevel { get; set; }
    }
}
