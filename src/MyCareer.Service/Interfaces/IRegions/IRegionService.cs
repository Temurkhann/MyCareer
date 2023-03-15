using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Service.DTOs.Regions;

namespace MyCareer.Service.Interfaces.IRegions
{
    public interface IRegionService
    {
        ValueTask<IQueryable<Region>> GetAll(PaginationParams @params, Expression<Func<Region, bool>> expression = null);
        ValueTask<Region> GetAsync(Expression<Func<Region, bool>> expression);
        ValueTask<Region> CreateAsync(RegionForCreationDTO regionForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Region> Update(int Id, RegionForCreationDTO regionForCreation);
    }
}
