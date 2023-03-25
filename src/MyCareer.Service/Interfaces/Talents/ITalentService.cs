using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Talents;
using MyCareer.Service.DTOs.Skills;
using MyCareer.Service.DTOs.Talents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Talents
{
    public interface ITalentService
    {
        ValueTask<IEnumerable<Talent>> GetAll(PaginationParams @params, Expression<Func<Talent, bool>> expression = null);
        ValueTask<Talent> GetAsync(Expression<Func<Talent, bool>> expression);
        ValueTask<Talent> CreateAsync(TalentForCreationDTO talentForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Talent> Update(int id, TalentForCreationDTO talentForCreation);
    }
}
