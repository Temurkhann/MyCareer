using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Freelancers;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Exceptions;
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
        private readonly IMapper mapper;

        public FreelancerService(IMapper mapper, IGenericRepository<Region> regionRepository, IGenericRepository<Country> countryRepository, IGenericRepository<Freelancer> freelancerRepository)
        {
            this.mapper = mapper;
            this.regionRepository = regionRepository;
            this.countryRepository = countryRepository;
            this.freelancerRepository = freelancerRepository;
        }

        public async ValueTask<Freelancer> CreateAsync(FreelancerForCreationDTO freelancerForCreationDTO)
        {
            var existCountry = await countryRepository.GetAsync(
                c => c.Id == freelancerForCreationDTO.Address.CountryId);

            if (existCountry == null)
                throw new MyCareerException(404, "No country found");

            var existRegion = await regionRepository.GetAsync(
                r => r.Id == freelancerForCreationDTO.Address.CountryId);

            if (existRegion == null)
                throw new MyCareerException(404, "No Region found");

            var createdFreelanser = await freelancerRepository.CreateAsync(mapper.Map<Freelancer>(freelancerForCreationDTO));
            await freelancerRepository.SaveChangesAsync();

            return createdFreelanser;
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
                throw new MyCareerException(404, "No freelncer was found");

            var existCountry = await countryRepository.GetAsync(
                c => c.Id == freelancerForCreationDTO.Address.CountryId);

            if (existCountry == null)
                throw new MyCareerException(404, "No country found");

            var existRegion = await regionRepository.GetAsync(
                r => r.Id == freelancerForCreationDTO.Address.CountryId);

            if (existRegion == null)
                throw new MyCareerException(404, "No Region found");

            existFreelancer.UpdatedAt = DateTime.UtcNow;
            existFreelancer = freelancerRepository.Update(mapper.Map(freelancerForCreationDTO, existFreelancer));
            await freelancerRepository.SaveChangesAsync();

            return existFreelancer;
        }
    }
}
