using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Service.DTOs.Regions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Addresses
{
    public interface IRegionService
    {
        ValueTask<IEnumerable<Region>> GetAll(PaginationParams @params, Expression<Func<Region, bool>> expression = null);
        ValueTask<Region> GetAsync(Expression<Func<Region, bool>> expression);
        ValueTask<Region> CreateAsync(RegionForCreationDTO regionForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Region> Update(int Id, RegionForCreationDTO regionForCreation);
    }
}
