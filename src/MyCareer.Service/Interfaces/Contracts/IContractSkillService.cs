using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Service.DTOs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Contracts
{
    public interface IContractSkillService
    {
        ValueTask<IEnumerable<ContractSkill>> GetAll(PaginationParams @params, Expression<Func<ContractSkill, bool>> expression = null);
        ValueTask<ContractSkill> GetAsync(Expression<Func<ContractSkill, bool>> expression);
        ValueTask<ContractSkill> CreateAsync(ContractSkillForCreationDTO contractSkillForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<ContractSkill> Update(int id, ContractSkillForCreationDTO contractSkillForCreationDTO);
    }
}
