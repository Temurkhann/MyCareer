using MyCareer.Domain.Commons;
using MyCareer.Domain.Enums;

namespace MyCareer.Domain.Entities.Jobs
{
    public class Job : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public RequiredLevel RequiredLevel { get; set; }
    }
}
