using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Skills;

namespace MyCareer.Domain.Entities.Contracts
{
    public class ContractSkill : Auditable
    {
        public int CompanyWorkerId { get; set; }
        public Company CompanyId { get; set; }
        public int RequiredSkillId { get; set;}
        public Skill RequiredSkill { get; set; }
    }
}