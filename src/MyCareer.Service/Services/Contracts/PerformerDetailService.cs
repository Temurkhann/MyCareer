using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Service.DTOs.Contracts;
using MyCareer.Service.Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Contracts
{
    public class PerformerDetailService : IPerformerDetailService
    {
        public ValueTask<PerformerDetails> CreateAsync(PerformerDetailForCreationDTO performerDetailForCreationDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<PerformerDetails>> GetAll(PaginationParams @params, Expression<Func<PerformerDetails, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PerformerDetails> GetAsync(Expression<Func<PerformerDetails, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PerformerDetails> Update(int id, PerformerDetailForCreationDTO performerDetailForCreationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
