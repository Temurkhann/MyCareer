using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Attachments;
using MyCareer.Service.DTOs.Freelancers;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Extensions;
using MyCareer.Service.Interfaces.Attachments;
using MyCareer.Service.Interfaces.Freelancers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Freelancers
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IGenericRepository<Freelancer> freelancerRepository;
        private readonly IGenericRepository<Country> countryRepository;
        private readonly IGenericRepository<Region> regionRepository;
        private readonly IGenericRepository<User> userRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IMapper mapper;

        public FreelancerService(IMapper mapper,
            IGenericRepository<Region> regionRepository,
            IGenericRepository<Country> countryRepository,
            IGenericRepository<Freelancer> freelancerRepository,
            IAttachmentService attachmentService,
            IGenericRepository<User> userRepository)
        {
            this.mapper = mapper;
            this.regionRepository = regionRepository;
            this.countryRepository = countryRepository;
            this.freelancerRepository = freelancerRepository;
            this.attachmentService = attachmentService;
            this.userRepository = userRepository;
        }

        public async ValueTask<Freelancer> CreateAsync(FreelancerForCreationDTO freelancerForCreationDTO)
        {
            var existUser = await userRepository.GetAsync(u => u.Id == freelancerForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404,"User not found");

            var existCountry = await countryRepository.GetAsync(
                c => c.Id == freelancerForCreationDTO.Address.CountryId);

            if (existCountry == null)
                throw new MyCareerException(404, "Country not found");

            var existRegion = await regionRepository.GetAsync(
                r => r.Id == freelancerForCreationDTO.Address.CountryId);

            if (existRegion == null)
                throw new MyCareerException(404, "Region not found");

            var createdFreelanser = await freelancerRepository.CreateAsync(mapper.Map<Freelancer>(freelancerForCreationDTO));

            await freelancerRepository.SaveChangesAsync();

            return createdFreelanser;
        }

        public async ValueTask<bool> CreateAttachmentAsync(int id, AttachmentForCreationDTO attachmentForCreationDTO)
        {
            var attachment = await attachmentService.UploadAsync(attachmentForCreationDTO);

            var company = await freelancerRepository.GetAsync(c => c.Id == id);

            if (company == null)
                throw new MyCareerException(404, "company not found");

            company.ImageId = attachment.Id;

            freelancerRepository.Update(company);

            await freelancerRepository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await freelancerRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Freeelancer not found");

            await freelancerRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Freelancer>> GetAll(PaginationParams @params, Expression<Func<Freelancer, bool>> expression = null)
        {
            var freelancers = freelancerRepository.GetAll(expression: expression, isTracking: false, includes: new string[] { "User" });

            return await freelancers.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Freelancer> GetAsync(Expression<Func<Freelancer, bool>> expression)
        {
            var freelancer = await freelancerRepository.GetAsync(expression, false,new string[] { "User", "Contact", "Address", "Attachment" });

            if (freelancer is null)
                throw new MyCareerException(404, "User not found");

            return freelancer;
        }

        public async ValueTask<Freelancer> Update(int id, FreelancerForCreationDTO freelancerForCreationDTO)
        {
            var existFreelancer = await freelancerRepository.GetAsync(f => f.Id == id);

            if (existFreelancer is null)
                throw new MyCareerException(404, "Freelancer not found");

            var existCountry = await countryRepository.GetAsync(
                c => c.Id == freelancerForCreationDTO.Address.CountryId);

            if (existCountry == null)
                throw new MyCareerException(404, "Country not found");

            var existRegion = await regionRepository.GetAsync(
                r => r.Id == freelancerForCreationDTO.Address.CountryId);

            if (existRegion == null)
                throw new MyCareerException(404, "Region not found");

            existFreelancer.UpdatedAt = DateTime.UtcNow;
            existFreelancer = freelancerRepository.Update(mapper.Map(freelancerForCreationDTO, existFreelancer));
            await freelancerRepository.SaveChangesAsync();

            return existFreelancer;
        }
    }
}
