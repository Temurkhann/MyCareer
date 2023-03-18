using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Talents;
using MyCareer.Service.DTOs.Talents;

namespace MyCareer.Service.Interfaces.Talents
{
    public interface ITalentService
    {
        ValueTask<IEnumerable<Talent>> GetAll(PaginationParams @params, Expression<Func<Talent, bool>> expression = null);
        ValueTask<Talent> GetAsync(Expression<Func<Talent, bool>> expression);
        ValueTask<Talent> CreateAsync(TalentForCreationDTO talentForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Talent> Update(int Id, TalentForCreationDTO talentForCreation);
    }
}
