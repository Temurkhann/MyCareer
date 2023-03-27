using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Domain.Entities.Skills;
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
    public class ContractSkillService : IContractSkillService
    {
        private readonly IGenericRepository<ContractSkill> contractSkillRepository;
        private readonly IGenericRepository<Company> companyRepository;
        private readonly IGenericRepository<Skill> skillRepository;
        private readonly IMapper mapper;

        public ContractSkillService(IGenericRepository<ContractSkill> contractSkillRepository,
            IGenericRepository<Company> companyRepository,
            IGenericRepository<Skill> skillRepository,
            IMapper mapper)
        {
            this.contractSkillRepository = contractSkillRepository;
            this.companyRepository = companyRepository;
            this.skillRepository = skillRepository;
            this.mapper = mapper;
        }

        public async ValueTask<ContractSkill> CreateAsync(ContractSkillForCreationDTO contractSkillForCreationDTO)
        {
            var existSkill = await skillRepository.GetAsync(s => s.Id == contractSkillForCreationDTO.RequiredSkillId);

            if (existSkill == null)
                throw new MyCareerException(404,"Skill not found");

            var existCompany = await companyRepository.GetAsync(c => c.Id == contractSkillForCreationDTO.CompanyWorkerId);

            if (existCompany == null)
                throw new MyCareerException(404, "Company not found");

            var createdContractSkill = await contractSkillRepository.CreateAsync(mapper.Map<ContractSkill>(contractSkillForCreationDTO));
            await contractSkillRepository.SaveChangesAsync();

            return createdContractSkill;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await contractSkillRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "ContractSkill not found");

            await contractSkillRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<ContractSkill>> GetAll(PaginationParams @params, Expression<Func<ContractSkill, bool>> expression = null)
        {
            var contracts = contractSkillRepository.GetAll(expression: expression, isTracking: false);

            return await contracts.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<ContractSkill> GetAsync(Expression<Func<ContractSkill, bool>> expression)
        {
            var contractSkill = await contractSkillRepository.GetAsync(expression);

            if (contractSkill is null)
                throw new MyCareerException(404, "ContractSkill not found");

            return contractSkill;
        }

        public async ValueTask<ContractSkill> UpdateAsync(int id, ContractSkillForCreationDTO contractSkillForCreationDTO)
        {
            var existContractSkill = await contractSkillRepository.GetAsync(c => c.Id == id);

            if (existContractSkill == null)
                throw new MyCareerException(404, "ContractSkill not found");

            var existSkill = await skillRepository.GetAsync(s => s.Id == contractSkillForCreationDTO.RequiredSkillId);

            if (existSkill == null)
                throw new MyCareerException(404, "Skill not found");

            var existCompany = await companyRepository.GetAsync(c => c.Id == contractSkillForCreationDTO.CompanyWorkerId);

            if (existCompany == null)
                throw new MyCareerException(404, "Company not found");

            existContractSkill.UpdatedAt = DateTime.UtcNow;
            contractSkillRepository.Update(existContractSkill);

            await contractSkillRepository.SaveChangesAsync();

            return existContractSkill;
        }
    }
}
