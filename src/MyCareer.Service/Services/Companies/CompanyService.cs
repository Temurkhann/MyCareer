using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Attachments;
using MyCareer.Service.DTOs.Companies;
using MyCareer.Service.DTOs.Freelancers;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Extensions;
using MyCareer.Service.Interfaces.Attachments;
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
        private readonly IGenericRepository<User> userRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IMapper mapper;

        public CompanyService(IGenericRepository<Company> companyRepository, IMapper mapper, IAttachmentService attachmentService, IGenericRepository<User> userRepository)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
            this.attachmentService = attachmentService;
            this.userRepository = userRepository;
        }

        public async ValueTask<Company> CreateAsync(CompanyForCreationDTO companyForCreationDTO)
        {
            var createAttachment = await attachmentService.UploadAsync(companyForCreationDTO.FormFile.ToAttachmentOrDefault());
            
            var existUser = await userRepository.GetAsync(u => u.Id == companyForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404,"User not found");

            var createdCompany = await companyRepository.CreateAsync(mapper.Map<Company>(companyForCreationDTO));

            createdCompany.ImageId = createAttachment.Id;
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
            var companies = companyRepository.GetAll(expression: expression, isTracking: false, includes: new string[] { "User", "Image", "CompanyInformation" });

            return await companies.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<bool> CreateAttachmentAsync(int id, AttachmentForCreationDTO attachmentForCreationDTO)
        {
            var attachment = await attachmentService.UploadAsync(attachmentForCreationDTO);

            var company = await companyRepository.GetAsync(c => c.Id == id);

            if (company == null)
                throw new MyCareerException(404,"company not found");

            company.ImageId = attachment.Id;

            companyRepository.Update(company);

            await companyRepository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<Company> GetAsync(Expression<Func<Company, bool>> expression)
        {
            var company = await companyRepository.GetAsync(expression, false, new string[] { "CompanyInformation", "User", "CompanyInformation.Contact", "Image" });

            if (company is null)
                throw new MyCareerException(404, "Company not found");

            return company;
        }

        public async ValueTask<Company> UpdateAsync(int id, CompanyForCreationDTO companyForCreationDTO)
        {
            var existFreelancer = await companyRepository.GetAsync(f => f.Id == id);

            if (existFreelancer is null)
                throw new MyCareerException(404, "Company not found");

            if (companyForCreationDTO.FormFile != null)
                await attachmentService.UpdateAsync((int)existFreelancer.ImageId, companyForCreationDTO.FormFile.ToAttachmentOrDefault().Stream);

            existFreelancer.UpdatedAt = DateTime.UtcNow;
            existFreelancer = companyRepository.Update(mapper.Map(companyForCreationDTO, existFreelancer));
            await companyRepository.SaveChangesAsync();

            return existFreelancer;
        }
    }
}
