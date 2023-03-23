﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Companies;
using MyCareer.Service.DTOs.Freelancers;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> companyRepository;
        private readonly IMapper mapper;

        public CompanyService(IGenericRepository<Company> companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Company> CreateAsync(CompanyForCreationDTO companyForCreationDTO)
        {
            var createdCompany = await companyRepository.CreateAsync(mapper.Map<Company>(companyForCreationDTO));

            await companyRepository.SaveChangesAsync();
            return createdCompany;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await companyRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Company not found");

            return isDeleted;
        }

        public async ValueTask<IEnumerable<Company>> GetAll(PaginationParams @params, Expression<Func<Company, bool>> expression = null)
        {
            var companies = companyRepository.GetAll(expression: expression, isTracking: false);

            return await companies.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Company> GetAsync(Expression<Func<Company, bool>> expression)
        {
            var company = await companyRepository.GetAsync(expression);

            if (company is null)
                throw new MyCareerException(404, "Company not found");

            return company;
        }

        public async ValueTask<Company> Update(int id, CompanyForCreationDTO companyForCreationDTO)
        {
            var existFreelancer = await companyRepository.GetAsync(f => f.Id == id);

            if (existFreelancer is null)
                throw new MyCareerException(404, "No company was found");

            existFreelancer.UpdatedAt = DateTime.UtcNow;
            existFreelancer = companyRepository.Update(mapper.Map(companyForCreationDTO, existFreelancer));
            await companyRepository.SaveChangesAsync();

            return existFreelancer;
        }
    }
}
