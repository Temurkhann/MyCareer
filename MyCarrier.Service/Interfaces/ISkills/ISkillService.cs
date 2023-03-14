using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Skills;
using MyCarrier.Domain.Entities.Users;
using MyCarrier.Service.DTOs.Skills;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.ISkills
{
    public interface ISkillService
    {
        IQueryable<Skill> GetAll(PaginationParams @params, Expression<Func<Skill, bool>> expression = null);
        ValueTask<Skill> GetAsync(Expression<Func<Skill, bool>> expression);
        ValueTask<Skill> CreateAsync(SkillForCreationDTO skillForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Skill Update(int Id, SkillForCreationDTO skillForCreation);
    }
}
