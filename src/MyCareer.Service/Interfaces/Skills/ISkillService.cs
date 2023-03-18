using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Service.DTOs.Skills;

namespace MyCareer.Service.Interfaces.Skills
{
    public interface ISkillService
    {
        ValueTask<IEnumerable<Skill>> GetAll(PaginationParams @params, Expression<Func<Skill, bool>> expression = null);
        ValueTask<Skill> GetAsync(Expression<Func<Skill, bool>> expression);
        ValueTask<Skill> CreateAsync(SkillForCreationDTO skillForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Skill> Update(int Id, SkillForCreationDTO skillForCreation);
    }
}
