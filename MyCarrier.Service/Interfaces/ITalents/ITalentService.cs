using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Talents;
using MyCarrier.Domain.Entities.Users;
using MyCarrier.Service.DTOs.Talents;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.Talents
{
    public interface ITalentService
    {
        IQueryable<Talent> GetAll(PaginationParams @params, Expression<Func<Talent, bool>> expression = null);
        ValueTask<Talent> GetAsync(Expression<Func<Talent, bool>> expression);
        ValueTask<Talent> CreateAsync(TalentForCreationDTO talentForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Talent Update(int Id, TalentForCreationDTO talentForCreation);
    }
}
