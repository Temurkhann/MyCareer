using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Service.DTOs.Contracts;

namespace MyCareer.Service.Interfaces.Contracts
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
