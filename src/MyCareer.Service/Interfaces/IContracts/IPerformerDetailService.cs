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
    public interface IPerformerDetailService
    {
        ValueTask<IQueryable<PerformerDetails>> GetAll(PaginationParams @params, Expression<Func<PerformerDetails, bool>> expression = null);
        ValueTask<PerformerDetails> GetAsync(Expression<Func<PerformerDetails, bool>> expression);
        ValueTask<PerformerDetails> CreateAsync(PerformerDetailForCreationDTO performerDetailForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<PerformerDetails> Update(int Id, PerformerDetailForCreationDTO performerDetailForCreationDTO);
    }
}
