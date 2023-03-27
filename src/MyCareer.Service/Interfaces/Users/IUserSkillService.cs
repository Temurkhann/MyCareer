using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.IUsers
{
    public interface IUserSkillService
    {
        ValueTask<IEnumerable<UserSkill>> GetAll(PaginationParams @params, Expression<Func<UserSkill, bool>> expression = null);
        ValueTask<UserSkill> GetAsync(Expression<Func<UserSkill, bool>> expression);
        ValueTask<UserSkill> CreateAsync(UserSkillForCreationDTO userSkillForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserSkill> UpdateAsync(int id, UserSkillForCreationDTO userSkillForCreation);
    }
}
