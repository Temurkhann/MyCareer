using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Service.DTOs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Contracts
{
    public interface IContractService
    {
        ValueTask<IEnumerable<Contract>> GetAll(PaginationParams @params, Expression<Func<Contract, bool>> expression = null);
        ValueTask<Contract> GetAsync(Expression<Func<Contract, bool>> expression);
        ValueTask<Contract> CreateAsync(ContractForCreationDTO contractForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Contract> Update(int id, ContractForCreationDTO contractForCreationDTO);
    }
}
