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
    public class ContractSkillService : IContractSkillService
    {
        public ValueTask<ContractSkill> CreateAsync(ContractSkillForCreationDTO contractSkillForCreationDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<ContractSkill>> GetAll(PaginationParams @params, Expression<Func<ContractSkill, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ContractSkill> GetAsync(Expression<Func<ContractSkill, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ContractSkill> Update(int id, ContractSkillForCreationDTO contractSkillForCreationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
