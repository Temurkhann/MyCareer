using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Users;
using MyCareer.Domain.Entities.Skills;

namespace MyCareer.Service.Interfaces.IUsers
{
    public interface IUserSkillService
    {
        ValueTask<IEnumerable<UserSkill>> GetAll(PaginationParams @params, Expression<Func<UserSkill, bool>> expression = null);
        ValueTask<UserSkill> GetAsync(Expression<Func<UserSkill, bool>> expression);
        ValueTask<UserSkill> CreateAsync(UserSkillForCreationDTO userSkillForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserSkill> Update(int Id, UserSkillForCreationDTO userSkillForCreation);
    }
}
