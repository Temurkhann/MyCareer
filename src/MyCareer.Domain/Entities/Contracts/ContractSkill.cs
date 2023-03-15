using MyCareer.Domain.Commons;

namespace MyCareer.Domain.Entities.Contracts
{
    public class ContractSkill : Auditable
    {
        public int CompanyWorkerId { get; set; }
        public int RequiredSkillId { get; set; }
    }
}
