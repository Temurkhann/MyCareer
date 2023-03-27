using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Service.DTOs.Countries;
using MyCareer.Service.DTOs.Skills;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Addresses
{
    public class CountryService : ICountryService
    {
        private readonly IGenericRepository<Country> countryRepository;
        private readonly IMapper mapper;

        public CountryService(IGenericRepository<Country> countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Country> CreateAsync(CountryForCreationDTO countryForCreationDTO)
        {
            var createdCountry = await countryRepository.CreateAsync(mapper.Map<Country>(countryForCreationDTO));
            await countryRepository.SaveChangesAsync();

            return createdCountry;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await countryRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Country not found");

            await countryRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Country>> GetAll(PaginationParams @params, Expression<Func<Country, bool>> expression = null)
        {
            var skills = countryRepository.GetAll(expression: expression, isTracking: false);

            return await skills.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Country> GetAsync(Expression<Func<Country, bool>> expression)
        {
            var skill = await countryRepository.GetAsync(expression, false);

            if (skill is null)
                throw new MyCareerException(404, "Country not found");

            return skill;
        }

        public async ValueTask<Country> UpdateAsync(int id, CountryForCreationDTO countryForCreationDTO)
        {
            var existSkill = await countryRepository.GetAsync(f => f.Id == id);

            if (existSkill is null)
                throw new MyCareerException(404, "Country not found");

            existSkill.UpdatedAt = DateTime.UtcNow;
            existSkill = countryRepository.Update(mapper.Map(countryForCreationDTO, existSkill));
            await countryRepository.SaveChangesAsync();

            return existSkill;
        }
    }
}
