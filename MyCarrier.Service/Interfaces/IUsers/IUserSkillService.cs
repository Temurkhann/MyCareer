using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Users;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.Users
{
    public interface IUserSkillService
    {
        IQueryable<UserSkill> GetAll(PaginationParams @params, Expression<Func<UserSkill, bool>> expression = null);
        ValueTask<UserSkill> GetAsync(Expression<Func<UserSkill, bool>> expression);
        ValueTask<UserSkill> CreateAsync(UserSkillForCreationDTO userSkillForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        UserSkill Update(int Id, UserSkillForCreationDTO userSkillForCreation);
    }
}
