using AutoMapper;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Contracts;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Contracts
{
    public class ContractService : IContractService
    {
        private readonly IGenericRepository<Freelancer> freelancerRepository;
        private readonly IGenericRepository<Company> companyRepository;
        private readonly IGenericRepository<Contract> contractRepository;
        private readonly IMapper mapper;

        public ContractService(IGenericRepository<Freelancer> freelancerRepository,
            IGenericRepository<Company> companyRepository,
            IGenericRepository<Contract> contractRepository,
            IMapper mapper)
        {
            this.freelancerRepository = freelancerRepository;
            this.companyRepository = companyRepository;
            this.contractRepository = contractRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Contract> CreateAsync(ContractForCreationDTO contractForCreationDTO)
        {
            var existFreelancer = await freelancerRepository.GetAsync(f => f.Id == contractForCreationDTO.PerformerId);

            if (existFreelancer == null)
                throw new MyCareerException(404,"Freelancer not found");

            var existCompany = await companyRepository.GetAsync(c => c.Id == contractForCreationDTO.CompanyWorkerId);
            
            if (existCompany == null)
                throw new 
        }

        public ValueTask<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<Contract>> GetAll(PaginationParams @params, Expression<Func<Contract, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Contract> GetAsync(Expression<Func<Contract, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Contract> Update(int id, ContractForCreationDTO contractForCreationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
