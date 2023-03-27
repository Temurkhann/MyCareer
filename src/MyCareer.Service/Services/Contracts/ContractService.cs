using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Contracts;
using MyCareer.Service.DTOs.Users;
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
                throw new MyCareerException(404,"Company not found");

            var createdContract = await contractRepository.CreateAsync(mapper.Map<Contract>(contractForCreationDTO));

            await contractRepository.SaveChangesAsync();

            return createdContract;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await contractRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Contract not found");

            await contractRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Contract>> GetAll(PaginationParams @params, Expression<Func<Contract, bool>> expression = null)
        {
            var contracts = contractRepository.GetAll(expression: expression, isTracking: false);

            return await contracts.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Contract> GetAsync(Expression<Func<Contract, bool>> expression)
        {
            var contract = await contractRepository.GetAsync(expression);

            if (contract is null)
                throw new MyCareerException(404, "User not found");

            return contract;
        }

        public async ValueTask<Contract> Update(int id, ContractForCreationDTO contractForCreationDTO)
        {
            var existContract = await contractRepository.GetAsync(c => c.Id == id);
            
            if (existContract == null)
                throw new MyCareerException(404, "Contract not found");

            
            var existFreelancer = await freelancerRepository.GetAsync(f => f.Id == contractForCreationDTO.PerformerId);

            if (existFreelancer == null)
                throw new MyCareerException(404, "Freelancer not found");


            var existCompany = await companyRepository.GetAsync(c => c.Id == contractForCreationDTO.CompanyWorkerId);

            if (existCompany == null)
                throw new MyCareerException(404, "Company not found");

            existContract.UpdatedAt = DateTime.UtcNow;
            existContract = contractRepository.Update(mapper.Map(contractForCreationDTO, existContract));
            await contractRepository.SaveChangesAsync();
            return existContract;
        }
    }
}
