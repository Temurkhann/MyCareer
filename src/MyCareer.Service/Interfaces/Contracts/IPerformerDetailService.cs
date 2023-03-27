using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Service.DTOs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Contracts
{
    public interface IPerformerDetailService
    {
        ValueTask<IEnumerable<PerformerDetails>> GetAll(PaginationParams @params, Expression<Func<PerformerDetails, bool>> expression = null);
        ValueTask<PerformerDetails> GetAsync(Expression<Func<PerformerDetails, bool>> expression);
        ValueTask<PerformerDetails> CreateAsync(PerformerDetailForCreationDTO performerDetailForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<PerformerDetails> UpdateAsync(int id, PerformerDetailForCreationDTO performerDetailForCreationDTO);
    }
}
