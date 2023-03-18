using AutoMapper;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Freelancers;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Freelancers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Users
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

        public ValueTask<IEnumerable<Freelancer>> GetAll(PaginationParams @params, Expression<Func<Freelancer, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Freelancer> GetAsync(Expression<Func<Freelancer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Freelancer> Update(int Id, FreelancerForCreationDTO freelancerForCreation)
        {
            throw new NotImplementedException();
        }
    }
}
