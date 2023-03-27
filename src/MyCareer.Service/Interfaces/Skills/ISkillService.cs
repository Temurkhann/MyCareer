using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Service.DTOs.Skills;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Skills
{
    public interface ISkillService
    {
        ValueTask<IEnumerable<Skill>> GetAll(PaginationParams @params, Expression<Func<Skill, bool>> expression = null);
        ValueTask<Skill> GetAsync(Expression<Func<Skill, bool>> expression);
        ValueTask<Skill> CreateAsync(SkillForCreationDTO skillForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Skill> UpdateAsync(int id, SkillForCreationDTO skillForCreation);
    }
}
