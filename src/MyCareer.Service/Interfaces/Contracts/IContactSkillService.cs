using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Service.DTOs.Contracts;

namespace MyCareer.Service.Interfaces.Contracts
{
    public interface IContactSkillService
    {
        ValueTask<IQueryable<ContractSkill>> GetAll(PaginationParams @params, Expression<Func<ContractSkill, bool>> expression = null);
        ValueTask<ContractSkill> GetAsync(Expression<Func<ContractSkill, bool>> expression);
        ValueTask<ContractSkill> CreateAsync(ContractSkillForCreationDTO contractSkillForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<ContractSkill> Update(int Id, ContractSkillForCreationDTO contractSkillForCreationDTO);
    }
}
