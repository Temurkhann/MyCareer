using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Service.DTOs.Countries;
using MyCareer.Service.DTOs.Regions;
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
    public class RegionService : IRegionService
    {
        private readonly IGenericRepository<Region> regionRespoitory;
        private readonly IMapper mapper;

        public RegionService(IGenericRepository<Region> regionRespoitory, IMapper mapper)
        {
            this.regionRespoitory = regionRespoitory;
            this.mapper = mapper;
        }

        public async ValueTask<Region> CreateAsync(RegionForCreationDTO regionForCreationDTO)
        {
            var createdCountry = await regionRespoitory.CreateAsync(mapper.Map<Region>(regionForCreationDTO));
            await regionRespoitory.SaveChangesAsync();

            return createdCountry;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await regionRespoitory.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Region not found");

            await regionRespoitory.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Region>> GetAll(PaginationParams @params, Expression<Func<Region, bool>> expression = null)
        {
            var skills = regionRespoitory.GetAll(expression: expression, isTracking: false);

            return await skills.ToPagedList(@params).ToListAsync();

        }

        public async ValueTask<Region> GetAsync(Expression<Func<Region, bool>> expression)
        {
            var skill = await regionRespoitory.GetAsync(expression, false);

            if (skill is null)
                throw new MyCareerException(404, "Region not found");

            return skill;
        }

        public async ValueTask<Region> UpdateAsync(int id, RegionForCreationDTO regionForCreation)
        {
            var existSkill = await regionRespoitory.GetAsync(f => f.Id == id);

            if (existSkill is null)
                throw new MyCareerException(404, "Region not found");

            existSkill.UpdatedAt = DateTime.UtcNow;
            existSkill = regionRespoitory.Update(mapper.Map(regionForCreation, existSkill));
            await regionRespoitory.SaveChangesAsync();

            return existSkill;
        }
    }
}
