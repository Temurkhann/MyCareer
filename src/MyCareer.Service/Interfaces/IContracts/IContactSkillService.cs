using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Domain.Entities.Educations;
using MyCareer.Service.DTOs.Contracts;
using MyCareer.Service.DTOs.Educations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.IContracts
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
