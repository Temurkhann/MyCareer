using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Regions;
using MyCarrier.Domain.Entities.Resumes;
using MyCarrier.Service.DTOs.Regions;
using MyCarrier.Service.DTOs.Resumes;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.IRegions
{
    public interface IRegionService
    {
        IQueryable<Region> GetAll(PaginationParams @params, Expression<Func<Region, bool>> expression = null);
        ValueTask<Region> GetAsync(Expression<Func<Region, bool>> expression);
        ValueTask<Region> CreateAsync(RegionForCreationDTO regionForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Region Update(int Id, RegionForCreationDTO regionForCreation);
    }
}
